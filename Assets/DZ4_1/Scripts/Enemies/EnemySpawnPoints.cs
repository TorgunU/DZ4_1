using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    public List<Transform> Points => new List<Transform>(_points);
}
