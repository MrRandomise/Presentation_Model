using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterManagerStats>().AsTransient();
            Container.Bind<CharacterInfo>().AsTransient();
            Container.Bind<CharacterStat>().AsTransient();

            Container.Bind<CharacterManager>().AsTransient();
            Container.Bind<CharacterManagerLevel>().AsTransient();
            Container.Bind<CharacterManagerInfo>().AsTransient();
            Container.Bind<PlayerLevel>().AsTransient();
            Container.Bind<UserInfo>().AsTransient();

            Container.Bind<StatFieldPool>().AsSingle();
        }
    }
}