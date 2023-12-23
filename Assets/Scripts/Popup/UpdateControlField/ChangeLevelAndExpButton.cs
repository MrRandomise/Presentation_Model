using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class ChangeLevelAndExpButton
    {
        private ServiceControlButton _serviceButton;

        private ServicePopup _servicePopup;

        private CharacterManagerLevel _characterLevelManager;

        private UpdateCharacterLevel _updateCharacterLevel;

        private PlayerLevel _playerLevel;

        public ChangeLevelAndExpButton(ServiceControlButton servicePopupButton, ServicePopup servicePopup)
        {
            _serviceButton = servicePopupButton;
            _servicePopup = servicePopup;
        }

        public void InitializeButtons(CharacterManagerLevel characterManagerLevel, UpdateCharacterLevel updateCharacterLevel)
        {
            _characterLevelManager = characterManagerLevel;
            _playerLevel = characterManagerLevel.GetLeveUp();
            _updateCharacterLevel = updateCharacterLevel;
            _servicePopup.LevelUp.LevelUpButton.onClick.AddListener(LevelUp);
            _serviceButton.AddExpControl.AddExp.onClick.AddListener(AddExperience);
            StatusLevelUpButton();
        }

        public void StatusLevelUpButton()
        {
            if (_playerLevel.CanLevelUp())
            {
                _servicePopup.LevelUp.LevelUpButton.image.sprite = _servicePopup.LevelUp.ActiveLevelButton;
            }
            else
            {
                _servicePopup.LevelUp.LevelUpButton.image.sprite = _servicePopup.LevelUp.DeactiveLevelButton;
            }
        }

        private void AddExperience()
        {
            var _addExp = _characterLevelManager.GetLeveUp();
            var field = _serviceButton.AddExpControl.AddExpField.text;
            if (TrygGetFieldWarning(_addExp, field))
            {
                _addExp.AddExperience(int.Parse(field));
                StatusLevelUpButton();
                _updateCharacterLevel.ShowLevelUp();
            }
        }

        private bool TrygGetFieldWarning(PlayerLevel level, string name)
        {
            if (level.CurrentExperience >= level.RequiredExperience)
            {
                Debug.LogWarning("You need to get a level up before you gain experience");
                return false;
            }
            if(string.IsNullOrWhiteSpace(name))
            {
                Debug.LogWarning("The value being added already exists");
                return false; 
            }
            return true;
        }

        private void LevelUp()
        {
            var _levelup = _characterLevelManager.GetLeveUp();
            _levelup.LevelUp();
            StatusLevelUpButton();
            _updateCharacterLevel.ShowLevelUp();
        }
    }
}
