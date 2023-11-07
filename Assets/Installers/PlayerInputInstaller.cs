using UnityEngine;
using Zenject;

public class PlayerInputInstaller : MonoInstaller
{
    [SerializeField] private Dekstop _dekstop;

    public override void InstallBindings()
    {
        BindPlayerInput();
    }

    private void BindPlayerInput()
    {
        Container.BindInstance(new InputActions());
        Dekstop dekstop = Container.InstantiatePrefabForComponent<Dekstop>(_dekstop, 
            FindObjectOfType<Player>().transform);
        Container.BindInterfacesAndSelfTo<PlayerInput>().FromInstance(dekstop).AsSingle();
    }
}