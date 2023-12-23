using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterManagerStats : IDisposable
    {
        private CharacterInfo _characterInfo;

        private StatFieldPool _statFieldPool;

        public CharacterManagerStats(StatFieldPool statFieldPool)
        {
            _characterInfo = new CharacterInfo();
            _statFieldPool = statFieldPool;
            _characterInfo.OnStatAdded += AddNewStat;
            _characterInfo.OnStatRemoved += RemoveStat;
        }

        public void Dispose()
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
