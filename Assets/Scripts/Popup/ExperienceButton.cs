using System;
using UnityEngine.UI;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class ExperienceButton : IInitializable, IDisposable
    {
        private Button _addExperience;
        private PlayerLevel _playerLevel;
        private int _experience;

        public ExperienceButton(ServicePopup expButton)
        {
            _addExperience = expButton.AddExperience;
        }

        public void InititializeButton(PlayerLevel level, int Exp)
        {
            _playerLevel = level;
            _experience = Exp;
        }

        public void Initialize()
        {
            _addExperience.onClick.AddListener(AddExp);
        }

        public void Dispose()
        {
            _addExperience.onClick.RemoveListener(AddExp);
        }

        private void AddExp()
        {
            _playerLevel.AddExperience(_experience);
        }
    }
}
