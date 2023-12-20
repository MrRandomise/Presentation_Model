using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class UpdateCharacterLevel
    {
        private ServicePopup _servicePopup;

        private CharacterManagerLevel _characterLevelManager;

        public UpdateCharacterLevel(ServicePopup servicePopup, ServicePopupButton servicePopupButton, CharacterManagerLevel characterLevelManager)
        {
            _servicePopup = servicePopup;
            _characterLevelManager = characterLevelManager;        
        }

        public void ShowLevelUp()
        {
            var _playerLevel = _characterLevelManager.GetLeveUp();
            _servicePopup.CharactterCurrLevel.text = $"Level : {_playerLevel.CurrentLevel}";
            _servicePopup.CurrentProgressBar.fillAmount = CurrentProgressBarValue(_playerLevel.CurrentExperience, _playerLevel.RequiredExperience);
            _servicePopup.CurrExp.text = $"XP : {_playerLevel.CurrentExperience}";
            _servicePopup.NeedExp.text = $"/ {_playerLevel.RequiredExperience}";
        }

        private float CurrentProgressBarValue(float currExp, float requiredExp)
        {
            return (float)currExp / requiredExp;
        }
    }
}
