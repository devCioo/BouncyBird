using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public static PipeSpawner instance;

    [SerializeField] private float _spawnRate = 1.5f;
    public float heightRange = 0.6f;
    public float pipesSpeed = 0.65f;

    [SerializeField] private GameObject _pipes;

    private float _timer;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipes), _spawnRate, _spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipes));
    }

    private void SpawnPipes()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipes = Instantiate(_pipes, spawnPos, Quaternion.identity);
    }
}
