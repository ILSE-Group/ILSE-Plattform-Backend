using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainObjects.Progresses
{
    internal class ExerciseProgress
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ExerciseId { get; private set; }
        public List<Guid> CompletedExercises { get; private set; }

        private ExerciseProgress()
        {
            CompletedExercises = [];
        }

        public ExerciseProgress(Guid userId, Guid exerciseId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            ExerciseId = exerciseId;
            CompletedExercises = [];
        }

        public void MarkAsCompleted()
        {
            CompletedExercises.Add(ExerciseId);
        }
    }
}
