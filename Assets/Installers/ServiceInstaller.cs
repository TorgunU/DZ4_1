using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private CoroutinePerformer _coroutinePerformer;

    public override void InstallBindings()
    {
        InstallPauseHandler();
        InstallCoroutinePerfomer();
    }

    public void InstallPauseHandler()
    {
        Container.BindInterfacesAndSelfTo<PauseHandler>().AsSingle().NonLazy();
    }

    public void InstallCoroutinePerfomer()
    {
        CoroutinePerformer performer = Container
            .InstantiatePrefabForComponent<CoroutinePerformer>(_coroutinePerformer);
        Container.Bind<ICoroutinePerformer>().To<CoroutinePerformer>().FromInstance(performer)
            .AsSingle().NonLazy();
    }
}
