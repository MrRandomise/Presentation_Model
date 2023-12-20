namespace Lessons.Architecture.PM
{
    public class UpdateCharacterInfo
    {
        ServicePopup _servicePopup;
        CharacterManagerInfo _characterInfo;

        public UpdateCharacterInfo(ServicePopup servicePopup, CharacterManagerInfo characterManagerInfo)
        {
            _servicePopup = servicePopup;
            _characterInfo = characterManagerInfo;
        }

        public void ShowInfo()
        {
            var _userInfo = _characterInfo.GetUserInfo();
            _servicePopup.CharacterName.text = _userInfo.Name;
            _servicePopup.CharacterDescription.text = _userInfo.Description;
            _servicePopup.CharacterIcon.sprite = _userInfo.Icon;
        }
    }
}
