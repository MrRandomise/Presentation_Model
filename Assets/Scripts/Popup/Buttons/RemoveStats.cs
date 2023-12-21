namespace Lessons.Architecture.PM
{
    public sealed class RemoveStats
    {
        private ServicePopupButton _servicePopupButton;

        private CharacterInfo _characterInfo;

        private UpdateCharacterStats _updateCharacterStats;

        private ServicePopupField _servicePopupField;

        private StatFieldPool _statField;

        private int _lastField = 1;

        public RemoveStats(ServicePopupButton servicePopupButton, ServicePopupField servicePopupField, StatFieldPool statField)
        {
            _servicePopupButton = servicePopupButton;
            _servicePopupField = servicePopupField;
            _statField = statField;
        }

        public void InitializeButtons(CharacterInfo characterInfo, UpdateCharacterStats updateCharacterStats)
        {
            _servicePopupButton.RemoveStats.onClick.AddListener(OnRemove);
            _updateCharacterStats = updateCharacterStats;
            _characterInfo = characterInfo;
        }

        public void OnRemove()
        {
            var stat = _characterInfo.GetStat(_servicePopupField.RemoveStatField.text);
            var statField = _statField.GetStatFieldList(_statField.GetCountFieldList() - _lastField);
            statField.gameObject.SetActive(false);
            _characterInfo.RemoveStat(stat);
            _updateCharacterStats.ShowStats();
        }
    }
}