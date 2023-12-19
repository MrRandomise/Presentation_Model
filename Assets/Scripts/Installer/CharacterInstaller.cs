using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterStatsManager>().AsTransient();
            Container.Bind<CharacterInfo>().AsTransient();
            Container.Bind<CharacterStat>().AsTransient();

            Container.Bind<CharacterLevelManager>().AsTransient();
            Container.Bind<PlayerLevel>().AsTransient();

            Container.Bind<CharacterManagerInfo>().AsSingle();
            Container.Bind<UserInfo>().AsSingle();
        }
    }
}