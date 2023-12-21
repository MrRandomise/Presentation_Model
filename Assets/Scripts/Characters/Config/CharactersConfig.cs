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

    }
}


