using UnityEngine;

namespace Lessons.Architecture.PM
{
    [CreateAssetMenu(
        fileName = "CharactersConfig",
        menuName = "Character/New Character"
    )]
    public sealed class CharactersConfig : ScriptableObject
    {
        public string Name;

        public string Description;

        public Sprite Icon;

        public Color CharacterColor;

        public CharacterStatsConfig StatsConfig;

        public int ExperienceAdd = 100;

        public int StatsChange = 1;

        public int Speed = 20;

        public int Intellegence = 55;

        public int Stamina = 25;

        public int Damage = 50;

        public int Dexterity = 25;

        public int Regeneration = 5;
    }
}


