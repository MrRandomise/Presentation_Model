using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class AddStatsButton 
    {
        private ServiceControlButton _servicePopupButton;

        private StatFieldPool _fieldPool;

        private CharacterInfo _characterInfo;

        private UpdateCharacterStats _updateCharacterStats;

        public AddStatsButton(ServiceControlButton servicePopupButton, StatFieldPool fieldPool)
        {
            _servicePopupButton = servicePopupButton;
            _fieldPool = fieldPool;
        }

        public void InitializeButtons(CharacterInfo characterInfo, UpdateCharacterStats updateCharacterStats)
        {
            _servicePopupButton.AddStatControl.AddStatButton.onClick.AddListener(OnAddStats);
            _updateCharacterStats = updateCharacterStats;
            _characterInfo = characterInfo;
        }

        public void OnAddStats()
        {
            var name = _servicePopupButton.AddStatControl.AddStatField.text;
            var value = _servicePopupButton.AddStatControl.AddStatValueField.text;
            if (TrygGetFieldWarning(name, value))
            {
                var stat = new CharacterStat(name, int.Parse(value));
                _characterInfo.AddStat(stat);
                _fieldPool.AddPool(_characterInfo);
                _updateCharacterStats.ShowStats();
            }
        }

        private bool TrygGetFieldWarning(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(value))
            {
                Debug.LogWarning("Field name and value should not be empty");
                return false;
            }
            if (_characterInfo.CheckStat(name))
            {
                Debug.LogWarning("The value being added already exists");
                return false;
            }
            return true;
        }
    }
}