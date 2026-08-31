using Application.DTOs;
using Application.IServices.IProgressServices;
using Domain.DomainObjects.Progresses;
using Domain.DomainObjects.Topics.Exercises;
using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.IRepositories.IProgressRepositories;
using Domain.IRepositories.ITopicRepositories;

namespace Application.Services.ProgressServices
{
    public class ExerciseProgressService(
        IExerciseProgressRepository exerciseProgressRepository,
        IExerciseRepository exerciseRepository) : IExerciseProgressService
    {
        private readonly IExerciseProgressRepository _exerciseProgressRepository = exerciseProgressRepository;
        private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

        public async Task<ExerciseProgressResponse?> GetByExerciseAndUserAsync(Guid exerciseId, Guid userId)
        {
            var progress = await _exerciseProgressRepository.GetByUserAndExerciseAsync(userId, exerciseId);
            return progress is null ? null : MapToResponse(progress);
        }

        public async Task<ExerciseProgressResponse> SubmitMultipleChoiceAsync(Guid exerciseId, SubmitMultipleChoiceAnswerRequest request)
        {
            var exercise = await GetExerciseOrThrowAsync<MultipleChoiceMultiAnswerExercise>(exerciseId);
            var isCorrect = exercise.ValidateAnswer(request.SelectedOptionIndices);
            return await SaveResultAsync(request.UserId, exerciseId, isCorrect, exercise.ExperiencePoints);
        }

        public async Task<ExerciseProgressResponse> SubmitDragAndDropAsync(Guid exerciseId, SubmitDragAndDropAnswerRequest request)
        {
            var exercise = await GetExerciseOrThrowAsync<DragAndDropExercise>(exerciseId);

            var mappings = request.Mappings
                .Select(m => (ItemIndex: m.ItemIndex, ZoneIndex: m.ZoneIndex))
                .ToList();

            var isCorrect = exercise.ValidateAnswer(mappings);
            return await SaveResultAsync(request.UserId, exerciseId, isCorrect, exercise.ExperiencePoints);
        }

        public async Task<ExerciseProgressResponse> SubmitLinkingAsync(Guid exerciseId, SubmitLinkingAnswerRequest request)
        {
            var exercise = await GetExerciseOrThrowAsync<LinkingExercise>(exerciseId);

            var links = request.Links
                .Select(l => (LeftIndex: l.LeftIndex, RightIndex: l.RightIndex))
                .ToList();

            var isCorrect = exercise.ValidateAnswer(links);
            return await SaveResultAsync(request.UserId, exerciseId, isCorrect, exercise.ExperiencePoints);
        }

        public async Task<ExerciseProgressResponse> SubmitClickableImageAsync(Guid exerciseId, SubmitClickableImageAnswerRequest request)
        {
            var exercise = await GetExerciseOrThrowAsync<ClickableImageExercise>(exerciseId);
            var isCorrect = exercise.ValidateAnswer((request.X, request.Y));
            return await SaveResultAsync(request.UserId, exerciseId, isCorrect, exercise.ExperiencePoints);
        }

        private async Task<TExercise> GetExerciseOrThrowAsync<TExercise>(Guid exerciseId) where TExercise : Exercise
        {
            var exercise = await _exerciseRepository.GetByIdAsync(exerciseId)
                ?? throw new KeyNotFoundException($"Exercise {exerciseId} not found.");

            if (exercise is not TExercise typedExercise)
                throw new InvalidOperationException(
                    $"Exercise {exerciseId} is of type {exercise.GetType().Name}, expected {typeof(TExercise).Name}.");

            return typedExercise;
        }

        private async Task<ExerciseProgressResponse> SaveResultAsync(Guid userId, Guid exerciseId, bool isCorrect, int experiencePoints)
        {
            var existing = await _exerciseProgressRepository.GetByUserAndExerciseAsync(userId, exerciseId);

            if (existing is null)
            {
                var progress = ExerciseProgress.CreateNew(userId, exerciseId);
                if (isCorrect)
                {
                    progress.MarkAsCompleted(experiencePoints);
                }
                await _exerciseProgressRepository.AddAsync(progress);
                return MapToResponse(progress);
            }

            if (isCorrect && !existing.Completed)
            {
                existing.MarkAsCompleted(experiencePoints);
                await _exerciseProgressRepository.UpdateAsync(existing);
            }

            return MapToResponse(existing);
        }

        private static ExerciseProgressResponse MapToResponse(ExerciseProgress progress) =>
            new(
                progress.Id,
                progress.ExerciseId,
                progress.UserId,
                progress.Completed,
                progress.ExperiencePointsEarned,
                progress.CompletedAt
            );
    }
}