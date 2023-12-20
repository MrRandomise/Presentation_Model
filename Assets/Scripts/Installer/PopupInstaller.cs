using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PopupInstaller : MonoInstaller
    {
        [SerializeField] private ServicePopup _ServicePopup;
        [SerializeField] private ServicePopupButton _popupButton;
        [SerializeField] private ServicePopupField _popupField;
        public override void InstallBindings()
        {
            Container.Bind<ServicePopup>().FromInstance(_ServicePopup).AsSingle();
            Container.Bind<ServicePopupButton>().FromInstance(_popupButton).AsSingle();
            Container.Bind<ServicePopupField>().FromInstance(_popupField).AsSingle();

            Container.Bind<PopupManager>().AsTransient();

            Container.BindInterfacesAndSelfTo<ClosePopup>().AsSingle();

            Container.Bind <ChangeLevelAndExpButton>().AsSingle();
            Container.Bind<AddStatsButton>().AsSingle();
            Container.Bind<ChangeStats>().AsSingle();
            Container.Bind<RemoveStats>().AsSingle();
        }
    }
}