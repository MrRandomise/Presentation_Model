using System;
using UnityEngine.UI;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class LevelUpButton : IInitializable, IDisposable
    {
        private Button _levelUpButton;
        private PlayerLevel _playerLevel;

        public LevelUpButton(ServicePopup expButton)
        {
            _levelUpButton = expButton.LevelUpButton;
        }

        public void InititializeButton(PlayerLevel level)
        {
            _playerLevel = level;
        }

        public void Initialize()
        {
            _levelUpButton.onClick.AddListener(AddLevel);
        }

        public void Dispose()
        {
            _levelUpButton.onClick.RemoveListener(AddLevel);
        }

        private void AddLevel()
        {
            _playerLevel.LevelUp();
            
        }
    }
}
