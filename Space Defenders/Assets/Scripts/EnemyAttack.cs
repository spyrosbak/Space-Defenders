using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private float spawnTime;
    public int killPoints;

    private GameManager gameManager;
    private float minSpawnTime = 5.0f;
    private float maxSpawnTime = 30.0f;
    private float spawnTimer;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(gameManager.state == GameManager.GameState.START)
        {
            if (spawnTimer <= 0)
            {
                Instantiate(enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180));
                spawnTimer = spawnTime;
            }
        }
    }
}