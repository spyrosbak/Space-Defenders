using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.state == GameManager.GameState.START)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
        }

        if (gameObject.transform.position.y < -6 || gameManager.state != GameManager.GameState.START)
        {
            Destroy(gameObject);
        }
    }
}