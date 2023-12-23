using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class RemoveStats
    {
        private ServiceControlButton _servicePopupButton;

        private CharacterInfo _characterInfo;

        private UpdateCharacterStats _updateCharacterStats;


        private StatFieldPool _statField;

        private int _lastField = 1;

        public RemoveStats(ServiceControlButton servicePopupButton, StatFieldPool statField)
        {
            _servicePopupButton = servicePopupButton;
            _statField = statField;
        }

        public void InitializeButtons(CharacterInfo characterInfo, UpdateCharacterStats updateCharacterStats)
        {
            _servicePopupButton.RemoveStatControl.RemoveStats.onClick.AddListener(OnRemove);
            _updateCharacterStats = updateCharacterStats;
            _characterInfo = characterInfo;
        }

        public void OnRemove()
        {
            if(_characterInfo.TryGetStat(_servicePopupButton.RemoveStatControl.RemoveStatField.text, out var stat))
            {
                var statField = _statField.GetStatFieldList(_statField.GetCountFieldList() - _lastField);
                statField.gameObject.SetActive(false);
                _characterInfo.RemoveStat(stat);
                _updateCharacterStats.ShowStats();
            }
            else
            {
                Debug.LogWarning($"Stat {_servicePopupButton.RemoveStatControl.RemoveStatField.text} is not found!");
            }
        }
    }
}