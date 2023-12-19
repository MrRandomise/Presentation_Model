using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PopupInstaller : MonoInstaller
    {
        [SerializeField] private ServicePopup _popupButton;
        [SerializeField] private ServiceStatsInfo _serviceStatsInfo;
        public override void InstallBindings()
        {
            Container.Bind<ServicePopup>().FromInstance(_popupButton).AsSingle();
            Container.Bind<ServiceStatsInfo>().FromInstance(_serviceStatsInfo).AsSingle();

            Container.BindInterfacesAndSelfTo<ClosePopup>().AsSingle();
            Container.BindInterfacesAndSelfTo<ExperienceButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelUpButton>().AsSingle();
        }
    }
}