using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainObjects.Progresses
{
    public class ExerciseProgress
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ExerciseId { get; private set; }
        public List<Guid> CompletedExercises { get; private set; }

        private ExerciseProgress(Guid id, Guid userId, Guid exerciseId, List<Guid> completedExercises)
        {
            Id = id;
            UserId = userId;
            ExerciseId = exerciseId;
            CompletedExercises = completedExercises ?? [];
        }

        public static ExerciseProgress CreateNew(Guid userId, Guid exerciseId)
        {
            return new ExerciseProgress(Guid.NewGuid(), userId, exerciseId, []);
        }

        public static ExerciseProgress Reconstruct(Guid id, Guid userId, Guid exerciseId, List<Guid> completedExercises)
        {
            return new ExerciseProgress(id, userId, exerciseId, completedExercises ?? []);
        }

        public void MarkAsCompleted()
        {
            if (!CompletedExercises.Contains(ExerciseId))
            {
                CompletedExercises.Add(ExerciseId);
            }
        }
    }
}
