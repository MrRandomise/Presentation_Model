using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class ChangeStats 
    {
        private ServiceControlButton _servicePopupButton;

        private CharacterInfo _characterInfo;

        private UpdateCharacterStats _updateCharacterStats;

        public ChangeStats(ServiceControlButton servicePopupButton)
        {
            _servicePopupButton = servicePopupButton;
        }

        public void InitializeButtons(CharacterInfo characterInfo, UpdateCharacterStats updateCharacterStats) 
        {
            _servicePopupButton.ChangeStatControl.ChangeStats.onClick.AddListener(OnChange);
            _updateCharacterStats = updateCharacterStats;
            _characterInfo = characterInfo;
        }

        public void OnChange()
        {
            if(_characterInfo.TryGetStat(_servicePopupButton.ChangeStatControl.ChangeStatField.text, out var stat))
            {
                if (int.TryParse(_servicePopupButton.ChangeStatControl.ChangeStatFieldValue.text, out int numberOfRows))
                {
                    stat.ChangeValue(numberOfRows);
                    _updateCharacterStats.ShowStats();
                }
                else
                {
                    Debug.LogWarning("Enter a numeric value!");
                }
            }
            else
            {
                Debug.LogWarning($"Stat {_servicePopupButton.RemoveStatControl.RemoveStatField.text} is not found!");
            }
        }
    }
}