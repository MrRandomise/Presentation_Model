using System;
using Zenject;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class ClosePopup : IInitializable, IDisposable
    {
        private ServicePopupButton _serviceButton;

        private GameObject _popup;

        private StatFieldPool _statFieldPool;

        public ClosePopup(ServicePopupButton service, StatFieldPool statFieldPool, ServicePopup servicePopup)
        {
            _serviceButton = service;
            _statFieldPool = statFieldPool;
            _popup = servicePopup.Popup;
        }

        public void Initialize()
        {
            _serviceButton.CloseButton.onClick.AddListener(OnClose);
        }

        public void Dispose()
        {
            _serviceButton.CloseButton.onClick.RemoveListener(OnClose);
        }

        private void OnClose()
        {
            _serviceButton.AddExperience.onClick.RemoveAllListeners();
            _serviceButton.LevelUpButton.onClick.RemoveAllListeners();
            _serviceButton.AddStats.onClick.RemoveAllListeners();
            _serviceButton.ChangeStats.onClick.RemoveAllListeners();
            _serviceButton.RemoveStats.onClick.RemoveAllListeners();

            for (int i = 0; i < _statFieldPool.GetCountFieldList(); i++)
            {
                var stat = _statFieldPool.GetStatFieldList(i);
                stat.gameObject.SetActive(false);
            }
            _popup.gameObject.SetActive(false);
        }
    }
}
