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
        public List<CharacterStat> StatsList = new List<CharacterStat>();
    }

}
