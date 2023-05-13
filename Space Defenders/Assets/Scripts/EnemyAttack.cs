using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject enemyProjectile;

    private float spawnTimer = 5.0f;
    private float minSpawnTime = 5.0f;
    private float maxSpawnTime = 15.0f;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180));
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}