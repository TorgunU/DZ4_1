using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject;

public class EnemySpawner : IPause
{
    private float _spawnCooldown;

    private List<Transform> _spawnPoints;

    private EnemyFactory _enemyFactory;

    private ICoroutinePerformer _corutinePerformer;
    private Coroutine _spawning;

    private bool _isPaused;

    private EnemySpawner(EnemyFactory enemyFactory, PauseHandler pauseHandler, EnemySpawnPoints spawnPoints, 
        ICoroutinePerformer corutinePerformer, EnemySpawnerConfig config)
    {
        _enemyFactory = enemyFactory;
        pauseHandler.Add(this);
        _spawnPoints = spawnPoints.Points;
        _corutinePerformer = corutinePerformer;

        InitConfig(config);
        
        StartWork();
    }

    private void InitConfig(EnemySpawnerConfig config)
    {
        _spawnCooldown = config.SpawnCooldown;
    }

    public void StartWork()
    {
        StopWork();

        _spawning = _corutinePerformer.PerformCoroutine(Spawning());
    }

    public void StopWork()
    {
        if (_spawning != null)
            _corutinePerformer.CancelCoroutine(_spawning);
    }

    private IEnumerator Spawning()
    {
        float time = 0;

        while (true)
        {
            while(time < _spawnCooldown)
            {
                if(_isPaused == false)
                    time += Time.deltaTime;

                yield return null;
            }

            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            time = 0;
        }
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;
}
