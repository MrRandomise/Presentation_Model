using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    [CreateAssetMenu(
        fileName = "CharactersStatConfig",
        menuName = "Character/New Stat"
    )]
    public sealed class CharacterStatsConfig : ScriptableObject
    {
        public List<Stats> StatsList = new List<Stats>();
    }

    [Serializable]
    public sealed class Stats
    {
        public string Name;
        public int Value;
        public int ChangeWithLevel;
    }
}
