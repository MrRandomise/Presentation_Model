using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterManagerLevel : IDisposable
    {
        private PlayerLevel _playerLevel;

        public CharacterManagerLevel()
        {
            _playerLevel = new PlayerLevel();
            _playerLevel.OnExperienceChanged += ExpAdd;
            _playerLevel.OnLevelUp += LevelUp;
        }

        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= ExpAdd;
            _playerLevel.OnLevelUp -= LevelUp;
        }

        private void ExpAdd(int exp)
        {
            Debug.Log($"{exp} experiences has been added");
        }

        private void LevelUp()
        {
            Debug.Log($"A new level has been obtained");
        }

        public PlayerLevel GetLeveUp()
        {
            return _playerLevel;
        }
    }
}
