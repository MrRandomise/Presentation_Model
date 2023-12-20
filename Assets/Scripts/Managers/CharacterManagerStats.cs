using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterManagerStats
    {
        private CharacterInfo _characterInfo;

        private StatFieldPool _statFieldPool;

        public CharacterManagerStats(CharacterInfo characterInfo, StatFieldPool statFieldPool)
        {
            _characterInfo = characterInfo;
            _statFieldPool = statFieldPool;
            _characterInfo.OnStatAdded += AddNewStat;
            _characterInfo.OnStatRemoved += RemoveStat;
        }

        ~CharacterManagerStats()
        {
            _characterInfo.OnStatAdded -= AddNewStat;
            _characterInfo.OnStatRemoved -= RemoveStat;
        }

        private void AddNewStat(CharacterStat stat)
        {
            Debug.Log($"a parameter {stat.Name} with the value has been added {stat.Value}");
        }

        private void RemoveStat(CharacterStat stat)
        {
            Debug.Log($"the stat {stat.Name} was deleted");
        }

        public void InitializeCharacterStats(CharactersConfig characterInfo)
        {
           foreach(CharacterStat characterStat in characterInfo.StatsConfig.StatsList)
           {
                _characterInfo.AddStat(characterStat);
           }
            _statFieldPool.AddPool(_characterInfo);
            
        }

        public CharacterInfo GetCharacterStats()
        {
            return _characterInfo;
        }

    }
}
