namespace Lessons.Architecture.PM
{
    public sealed class CharacterLevelManager
    {
        public PlayerLevel PlayerLevel;
        private ServicePopup _servicePopup;

        public CharacterLevelManager(ServicePopup servicePopup, PlayerLevel playerLevel)
        {
            _servicePopup = servicePopup;
            PlayerLevel = playerLevel;
            PlayerLevel.OnExperienceChanged += ShowExp;
            PlayerLevel.OnLevelUp += ShowLevelUp;
        }

        ~CharacterLevelManager()
        {
            PlayerLevel.OnExperienceChanged -= ShowExp;
            PlayerLevel.OnLevelUp -= ShowLevelUp;
        }

        private void ShowExp(int exp)
        {
            ShowLevelUp();
        }

        public void ShowLevelUp()
        {
            if (PlayerLevel.CanLevelUp())
                _servicePopup.LevelUpButton.image.sprite = _servicePopup.ActiveLevelButton;
            else
                _servicePopup.LevelUpButton.image.sprite = _servicePopup.DeactiveLevelButton;
            _servicePopup.CharactterCurrLevel.text = $"Level : {PlayerLevel.CurrentLevel}";
            _servicePopup.CurrentProgressBar.fillAmount = CurrentProgressBarValue();
            _servicePopup.CurrExp.text = $"XP : {PlayerLevel.CurrentExperience}";
            _servicePopup.NeedExp.text = $"/ {PlayerLevel.RequiredExperience}";
        }

        private float CurrentProgressBarValue()
        {
            return (float)PlayerLevel.CurrentExperience  / PlayerLevel.RequiredExperience;
        }
    }
}
