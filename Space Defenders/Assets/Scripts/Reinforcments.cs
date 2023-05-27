using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforcments : MonoBehaviour
{
    public float moveSpeed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.state == GameManager.GameState.START)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x <= -15f)
        {
            transform.position = new Vector2(15.0f, transform.position.y - 0.5f);
            moveSpeed *= 1.15f;
        }
    }
}