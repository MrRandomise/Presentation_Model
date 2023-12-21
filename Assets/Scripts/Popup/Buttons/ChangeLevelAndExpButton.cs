using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class ChangeLevelAndExpButton : IButton<CharacterManagerLevel, UpdateCharacterLevel>
    {
        private ServicePopupButton _serviceButton;

        private ServicePopup _servicePopup;

        private CharacterManagerLevel _characterLevelManager;

        private UpdateCharacterLevel _updateCharacterLevel;

        private PlayerLevel _playerLevel;

        private ServicePopupField _servicePopupField;

        public ChangeLevelAndExpButton(ServicePopupButton servicePopupButton, ServicePopup servicePopup, ServicePopupField servicePopupField)
        {
            _serviceButton = servicePopupButton;
            _servicePopup = servicePopup;
            _servicePopupField = servicePopupField;
        }

        public void InitializeButtons(CharacterManagerLevel characterManagerLevel, UpdateCharacterLevel updateCharacterLevel)
        {
            _characterLevelManager = characterManagerLevel;
            _playerLevel = characterManagerLevel.GetLeveUp();
            _updateCharacterLevel = updateCharacterLevel;
            _serviceButton.LevelUpButton.onClick.AddListener(LevelUp);
            _serviceButton.AddExperience.onClick.AddListener(AddExperience);
            StatusLevelUpButton();
        }

        public void StatusLevelUpButton()
        {
            if (_playerLevel.CanLevelUp())
            {
                _serviceButton.LevelUpButton.image.sprite = _servicePopup.ActiveLevelButton;
            }
            else
            {
                _serviceButton.LevelUpButton.image.sprite = _servicePopup.DeactiveLevelButton;
            }
        }

        private void AddExperience()
        {
            var _addExp = _characterLevelManager.GetLeveUp();
            var field = _servicePopupField.AddExpField.text;
            if (CheckField(_addExp, field))
            {
                _addExp.AddExperience(int.Parse(field));
                StatusLevelUpButton();
                _updateCharacterLevel.ShowLevelUp();
            }
        }

        private bool CheckField(PlayerLevel level, string name)
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
