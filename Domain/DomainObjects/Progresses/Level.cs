namespace Domain.DomainObjects.Progresses
{
    public class Level
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ToolImage { get; private set; }
        public int ExperiencePoints { get; private set; }

        private Level(Guid id, string name, string toolImage, int experiencePoints)
        {
            Id = id;
            Name = name;
            ToolImage = toolImage;
            ExperiencePoints = experiencePoints;
        }

        public static Level CreateNew(string name, string toolImage, int experiencePoints)
        {
            return new Level(Guid.NewGuid(), name, toolImage, experiencePoints);
        }

        public static Level Reconstruct(Guid id, string name, string toolImage, int experiencePoints)
        {
            return new Level(id, name, toolImage, experiencePoints);
        }
    }
}