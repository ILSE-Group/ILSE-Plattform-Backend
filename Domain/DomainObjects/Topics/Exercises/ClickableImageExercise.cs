using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;

namespace Domain.DomainObjects.Topics.Exercises
{
    public class ClickableImageExercise : Exercise
    {
        public string ImageUrl { get; private set; }
        public List<ClickableArea> ClickableAreas { get; private set; }

        private ClickableImageExercise() : base(Guid.Empty, string.Empty, string.Empty, 0)
        {
            ImageUrl = string.Empty;
            ClickableAreas = [];
        }

        public ClickableImageExercise(Guid id, string title, string description, int experiencePoints) 
            : base(id, title, description, experiencePoints)
        {
            ImageUrl ??= string.Empty;
            ClickableAreas ??= [];
        }

        public override Exercise ValidateAnswer(object answer)
        {
            throw new NotImplementedException();
        }

    }
}
