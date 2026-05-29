using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainObjects.Topics
{
    internal class Room
    {
        public Guid Id { get; private set; }
        public Guid SectionId { get; private set; }
        public string Name { get; private set; }
        public List<Exercises.BaseExercise.Exercise> Exercises { get; private set; }
        public int UnlockLevel { get; private set; }
        public int CompletionExperiencePoints { get; private set; }

        private Room()
        {
            Name = string.Empty;
            Exercises = [];
        }

        public Room(string name, Guid sectionId)
        {
            Id = Guid.NewGuid();
            Name = name;
            SectionId = sectionId;
            Exercises = [];
            UnlockLevel = 0;
            CompletionExperiencePoints = 0;
        }
    }
}
