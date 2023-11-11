using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 1.5f;
    [SerializeField] private float _heightRange = 0.6f;
    [SerializeField] private GameObject _pipes;

    private float _timer;

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
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipes = Instantiate(_pipes, spawnPos, Quaternion.identity);
    }
}
