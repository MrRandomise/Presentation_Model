using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class ChangeStats 
    {
        private ServicePopupButton _servicePopupButton;

        private CharacterInfo _characterInfo;

        private UpdateCharacterStats _updateCharacterStats;
        
        private ServicePopupField _servicePopupField;

        public ChangeStats(ServicePopupButton servicePopupButton, ServicePopupField servicePopupField)
        {
            _servicePopupButton = servicePopupButton;
            _servicePopupField = servicePopupField;
        }

        public void InitializeButtons(CharacterInfo characterInfo, UpdateCharacterStats updateCharacterStats) 
        {
            _servicePopupButton.ChangeStats.onClick.AddListener(OnChange);
            _updateCharacterStats = updateCharacterStats;
            _characterInfo = characterInfo;
        }

        public void OnChange()
        {
            var stat = _characterInfo.GetStat(_servicePopupField.ChangeStatField.text);
            if (int.TryParse(_servicePopupField.ChangeStatFieldValue.text, out int numberOfRows))
            {
                stat.ChangeValue(numberOfRows);
                _updateCharacterStats.ShowStats();
            }
            else
            {
                Debug.LogWarning("Enter a numeric value!");
            }
        }
    }
}