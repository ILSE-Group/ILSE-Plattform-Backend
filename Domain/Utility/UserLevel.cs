using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Utility
{
    internal class UserLevel
    {
        public static int CalculateLevel(int experiencePoints)
        {
            // Function to calculate user level based on experience points
            return experiencePoints / 1000;
        }

        public static int CalculateExperiencePointsForLevel(int level)
        {
            // Function to calculate the experience points required for a specific level
            return level * 1000;
        }

        public static int CalculateExperiencePointsToNextLevel(int experiencePoints)
        {
            // Function to calculate the experience points needed to reach the next level
            int currentLevel = CalculateLevel(experiencePoints);
            int nextLevelExperiencePoints = CalculateExperiencePointsForLevel(currentLevel + 1);
            return nextLevelExperiencePoints - experiencePoints;
        }
    }
}
