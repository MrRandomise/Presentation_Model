using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PopupManager
    {
        private GameObject _popup;
        private CharacterManagerInfo _userInfo;
        private CharacterLevelManager _characterLevelManager;
        private LevelUpButton _levelUpButton;
        private ExperienceButton _experienceButton;
        private CharacterStatsManager _characterStatsManager;

        public PopupManager()
        {
            _popup = servicePopup.Popup;
            _userInfo = userInfo;
            _characterLevelManager = characterLevelManager;
            _levelUpButton = levelButton;
            _experienceButton = experienceButton;
            _characterStatsManager = characterStatsManager;
        }


        public void ShowPopupCharacter(CharactersConfig characterInfo)
        {
            _userInfo.ShowInfo(characterInfo.name, characterInfo.Description, characterInfo.Icon);
            _experienceButton.InititializeButton(_characterLevelManager.PlayerLevel, characterInfo.ExperienceAdd);
            _levelUpButton.InititializeButton(_characterLevelManager.PlayerLevel);
            _characterStatsManager.ShowStatsInfo(characterInfo);
            _characterLevelManager.ShowLevelUp();
            _popup.SetActive(true);
        }
    }
}
