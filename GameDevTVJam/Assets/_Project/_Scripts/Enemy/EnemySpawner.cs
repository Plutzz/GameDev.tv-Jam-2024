using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float spawnTime = 3f;
    private float timer;
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            timer = spawnTime;
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}
