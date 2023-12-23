using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterManagerInfo : IDisposable
    {
        private UserInfo _userInfo;

        public CharacterManagerInfo()
        {
            _userInfo = new UserInfo();
            _userInfo.OnNameChanged += SetName;
            _userInfo.OnDescriptionChanged += SetDesription;
            _userInfo.OnIconChanged += SetIcon;
        }

        public void Dispose()
        {
            _userInfo.OnNameChanged -= SetName;
            _userInfo.OnDescriptionChanged -= SetDesription;
            _userInfo.OnIconChanged -= SetIcon;
        }

        private void SetName(string name)
        {
            Debug.Log($"Name has ben changed as {name}");
        }

        private void SetDesription(string description)
        {
            Debug.Log($"Descrition has ben changed as {description}");
        }
        
        private void SetIcon(Sprite icon)
        {
            Debug.Log($"Icon has ben changed");
        }

        public void InitializeCharacterInfo(string name, string description, Sprite icon)
        {
            _userInfo.ChangeName(name);
            _userInfo.ChangeDescription(description);
            _userInfo.ChangeIcon(icon);
        }

        public UserInfo GetUserInfo()
        {
            return _userInfo;
        }
    }
}
