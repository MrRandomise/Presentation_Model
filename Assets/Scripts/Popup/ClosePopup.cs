using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class ClosePopup : IInitializable, IDisposable
    {
        private Button _closeButton;
        private GameObject _Popup;

        public ClosePopup(ServicePopup button)
        {
            _closeButton = button.CloseButton;
            _Popup = button.Popup;
        }

        public void Initialize()
        {
            _closeButton.onClick.AddListener(OnClose);
        }

        public void Dispose()
        {
            _closeButton.onClick.RemoveListener(OnClose);
        }
        private void OnClose()
        {
            _Popup.gameObject.SetActive(false);
        }
    }
}
