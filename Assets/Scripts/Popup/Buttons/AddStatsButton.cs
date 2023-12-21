using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class AddStatsButton 
    {
        private ServicePopupButton _servicePopupButton;

        private StatFieldPool _fieldPool;

        private CharacterInfo _characterInfo;

        private UpdateCharacterStats _updateCharacterStats;

        private ServicePopupField _servicePopupField;

        public AddStatsButton(ServicePopupButton servicePopupButton, StatFieldPool fieldPool, ServicePopupField servicePopupField)
        {
            _servicePopupButton = servicePopupButton;
            _servicePopupField = servicePopupField;
            _fieldPool = fieldPool;
        }

        public void InitializeButtons(CharacterInfo characterInfo, UpdateCharacterStats updateCharacterStats)
        {
            _servicePopupButton.AddStats.onClick.AddListener(OnAddStats);
            _updateCharacterStats = updateCharacterStats;
            _characterInfo = characterInfo;
        }

        public void OnAddStats()
        {
            var name = _servicePopupField.AddStatField.text;
            var value = _servicePopupField.AddStatValueField.text;
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