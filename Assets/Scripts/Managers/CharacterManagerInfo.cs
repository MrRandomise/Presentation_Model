using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterManagerInfo
    {
        private UserInfo _userInfo;
        private ServicePopup _servicePopup;

        public CharacterManagerInfo(ServicePopup servicePopup, UserInfo userInfo)
        {
            _servicePopup = servicePopup;
            _userInfo = userInfo;
            _userInfo.OnNameChanged += SetName;
            _userInfo.OnDescriptionChanged += SetDesription;
            _userInfo.OnIconChanged += SetIcon;
        }

        ~CharacterManagerInfo()
        {
            _userInfo.OnNameChanged -= SetName;
            _userInfo.OnDescriptionChanged -= SetDesription;
            _userInfo.OnIconChanged -= SetIcon;
        }

        private void SetName(string name)
        {
            _servicePopup.CharacterName.text = name;
        }

        private void SetDesription(string description)
        {
            _servicePopup.CharacterDescription.text = description;
        }
        
        private void SetIcon(Sprite icon)
        {
            _servicePopup.CharacterIcon.sprite = icon;
        }

        public void ShowInfo(string name, string description, Sprite icon)
        {
            _userInfo.ChangeName(name);
            _userInfo.ChangeDescription(description);
            _userInfo.ChangeIcon(icon);
        }
    }
}
