using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class ChangeLevelAndExpButton
    {
        private ServicePopupButton _serviceButton;

        private ServicePopup _servicePopup;

        private CharacterManagerLevel _characterLevelManager;

        private UpdateCharacterLevel _updateCharacterLevel;

        private PlayerLevel _playerLevel;

        private int _experience;

        public ChangeLevelAndExpButton(ServicePopupButton servicePopupButton, ServicePopup servicePopup)
        {
            _serviceButton = servicePopupButton;
            _servicePopup = servicePopup;
        }

        public void InitialButton(CharacterManagerLevel characterManagerLevel, UpdateCharacterLevel updateCharacterLevel, int exp)
        {
            _characterLevelManager = characterManagerLevel;
            _playerLevel = characterManagerLevel.GetLeveUp();
            _updateCharacterLevel = updateCharacterLevel;
            _experience = exp;
            ActivateButton();
        }

        public void ActivateButton()
        {
            if (_playerLevel.CanLevelUp())
            {
                _serviceButton.LevelUpButton.onClick.AddListener(LevelUp);
                _serviceButton.AddExperience.onClick.RemoveListener(AddExperience);
                _serviceButton.LevelUpButton.image.sprite = _servicePopup.ActiveLevelButton;
            }
            else
            {
                _serviceButton.AddExperience.onClick.AddListener(AddExperience);
                _serviceButton.LevelUpButton.onClick.RemoveListener(LevelUp);
                _serviceButton.LevelUpButton.image.sprite = _servicePopup.DeactiveLevelButton;
            }
        }

        private void AddExperience()
        {
            var _addExp = _characterLevelManager.GetLeveUp();
            if (_addExp.CurrentExperience >= _addExp.RequiredExperience)
            {
                Debug.LogWarning("You need to get a level up before you gain experience");
            }
            else
            {
                _addExp.AddExperience(_experience);
            }
            ActivateButton();
            _updateCharacterLevel.ShowLevelUp();
        }

        private void LevelUp()
        {
            var _levelup = _characterLevelManager.GetLeveUp();
            _levelup.LevelUp();
            ActivateButton();
            _updateCharacterLevel.ShowLevelUp();
        }
    }
}
