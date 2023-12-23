using System;
using Zenject;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class ClosePopup : IInitializable, IDisposable
    {
        private ServiceControlButton _serviceButton;

        private ServicePopup _servicePopup;

        private StatFieldPool _statFieldPool;

        public ClosePopup(ServiceControlButton service, StatFieldPool statFieldPool, ServicePopup servicePopup)
        {
            _serviceButton = service;
            _statFieldPool = statFieldPool;
            _servicePopup = servicePopup;
        }

        public void Initialize()
        {
            _servicePopup.CloseButton.onClick.AddListener(OnClose);
        }

        public void Dispose()
        {
            _servicePopup.CloseButton.onClick.RemoveListener(OnClose);
        }

        private void OnClose()
        {
            _servicePopup.LevelUp.LevelUpButton.onClick.RemoveAllListeners();
            _serviceButton.AddExpControl.AddExp.onClick.RemoveAllListeners();
            _serviceButton.AddStatControl.AddStatButton.onClick.RemoveAllListeners();
            _serviceButton.ChangeStatControl.ChangeStats.onClick.RemoveAllListeners();
            _serviceButton.RemoveStatControl.RemoveStats.onClick.RemoveAllListeners();

            for (int i = 0; i < _statFieldPool.GetCountFieldList(); i++)
            {
                var stat = _statFieldPool.GetStatFieldList(i);
                stat.gameObject.SetActive(false);
            }
            _servicePopup.Popup.gameObject.SetActive(false);
        }
    }
}
