using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterManagerStats>().AsTransient();

            Container.Bind<CharacterManager>().AsTransient();

            Container.Bind<StatFieldPool>().AsSingle();
        }
    }
}