using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PopupInstaller : MonoInstaller
    {
        [SerializeField] private ServicePopup _ServicePopup;
        [SerializeField] private ServiceControlButton _popupButton;

        public override void InstallBindings()
        {
            Container.Bind<ServicePopup>().FromInstance(_ServicePopup).AsSingle();
            Container.Bind<ServiceControlButton>().FromInstance(_popupButton).AsSingle();

            Container.Bind<PopupManager>().AsTransient();

            Container.BindInterfacesAndSelfTo<ClosePopup>().AsSingle();

            Container.Bind <ChangeLevelAndExpButton>().AsSingle();
            Container.Bind<AddStatsButton>().AsSingle();
            Container.Bind<ChangeStats>().AsSingle();
            Container.Bind<RemoveStats>().AsSingle();
        }
    }
}