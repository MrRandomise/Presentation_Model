namespace Lessons.Architecture.PM
{
    public sealed class PopupManager
    {
        private CharacterManager _characterManager;
        private UpdateCharacterInfo _updateCharacterInfo;
        private UpdateCharacterLevel _updateCharacterLevel;
        private UpdateCharacterStats _updateCharacterStats;
        
        private ServicePopup _servicePopup;
        private ServiceControlButton _servicePopupButton;

        private ChangeLevelAndExpButton _expAndLevelButton;
        private AddStatsButton _addStats;
        private ChangeStats _changeStats;
        private RemoveStats _removeStats;

        public PopupManager(ServicePopup servicePopup, ServiceControlButton serviceButton, ChangeLevelAndExpButton changeLevelAndExpButton, AddStatsButton addStats, ChangeStats changeStats, RemoveStats removeStats)
        {
            _servicePopup = servicePopup;
            _servicePopupButton = serviceButton;
            _expAndLevelButton = changeLevelAndExpButton;
            _addStats = addStats;
            _changeStats = changeStats;
            _removeStats = removeStats;
        }

        public void PopupInitialize(CharacterManager characterManager)
        {
            _characterManager = characterManager;
            var _characterInfo = characterManager.GetManagerInfo();
            var _characterLevelManager = characterManager.GetManagerLevel();
            var _characterStatsManager = characterManager.GetManagerStats();
            var _statsFieldPool = characterManager.GetStatsFieldPool();
            var _characterConfig = characterManager.GetCharacterConfig();
            _updateCharacterInfo = new UpdateCharacterInfo(_servicePopup, _characterInfo);
            _updateCharacterLevel = new UpdateCharacterLevel(_servicePopup, _characterLevelManager);
            _updateCharacterStats = new UpdateCharacterStats(_characterStatsManager, _statsFieldPool);
        }

        private void ButtonInitialize()
        {
            var _statConfig = _characterManager.GetCharacterConfig();
            var _characterInfo = _characterManager.GetManagerStats().GetCharacterStats();
            var _characterLevelManager = _characterManager.GetManagerLevel();
            var _characterConfig = _characterManager.GetCharacterConfig();
            _addStats.InitializeButtons(_characterInfo, _updateCharacterStats);
            _changeStats.InitializeButtons(_characterInfo, _updateCharacterStats);
            _removeStats.InitializeButtons(_characterInfo, _updateCharacterStats);
            _expAndLevelButton.InitializeButtons(_characterLevelManager, _updateCharacterLevel);
        }

        public void ShowPopupCharacter()
        {
            ButtonInitialize();
            _updateCharacterInfo.ShowInfo();
            _updateCharacterLevel.ShowLevelUp();
            _updateCharacterStats.ShowStats();
            _servicePopup.Popup.SetActive(true);
        }
    }
}
