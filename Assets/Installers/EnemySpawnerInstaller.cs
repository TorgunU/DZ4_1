using System;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private CorutinePerformer _corutinePerformer;
    [SerializeField] private EnemySpawnPoints _spawnPoints;
    [SerializeField] private EnemySpawnerConfig _config;

    public override void InstallBindings()
    {
        InstallFactory();
        InstallCoroutinePerfomer();
        InstallSpawnerConfig();
        InstallSpawnPoints();
        InstallSpawner();
    }

    public void InstallFactory()
    {
        Container.Bind<EnemyFactory>().AsSingle();
    }

    public void InstallCoroutinePerfomer()
    {
        Container.Bind<ICoroutinePerformer>().FromInstance(_corutinePerformer).AsSingle();
    }

    public void InstallSpawnerConfig()
    {
        Container.Bind<EnemySpawnerConfig>().FromInstance(_config).AsSingle();
    }

    public void InstallSpawnPoints()
    {
        Container.Bind<EnemySpawnPoints>().FromInstance(_spawnPoints).AsSingle();
    }

    public void InstallSpawner()
    {
        Container.Bind<EnemySpawner>().AsSingle().NonLazy();
    }
}
