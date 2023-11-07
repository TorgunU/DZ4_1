using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfigs/EnemySpawnerConfig")]
public class EnemySpawnerConfig : ScriptableObject
{
    [SerializeField] private float _spawnCooldown;

    public float SpawnCooldown => _spawnCooldown;
}
