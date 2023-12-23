namespace Lessons.Architecture.PM
{
    public class UpdateCharacterLevel
    {
        private ServicePopup _servicePopup;

        private CharacterManagerLevel _characterLevelManager;

        public UpdateCharacterLevel(ServicePopup servicePopup, CharacterManagerLevel characterLevelManager)
        {
            _servicePopup = servicePopup;
            _characterLevelManager = characterLevelManager;        
        }

        public void ShowLevelUp()
        {
            var _playerLevel = _characterLevelManager.GetLeveUp();
            _servicePopup.Info.CharactterCurrLevel.text = $"Level : {_playerLevel.CurrentLevel}";
            _servicePopup.ProgressBar.CurrentProgressBar.fillAmount = CurrentProgressBarValue(_playerLevel.CurrentExperience, _playerLevel.RequiredExperience);
            _servicePopup.ProgressBar.Exp.text = $"XP : {_playerLevel.CurrentExperience} / {_playerLevel.RequiredExperience}";
        }

        private float CurrentProgressBarValue(float currExp, float requiredExp)
        {
            return (float)currExp / requiredExp;
        }
    }
}
