using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private float spawnTime;

    private float minSpawnTime = 5.0f;
    private float maxSpawnTime = 30.0f;
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180));
            spawnTimer = spawnTime;
        }
    }
}
