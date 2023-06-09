using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject reinforcements;

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
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= 4f || transform.position.x <= -4f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
                moveSpeed *= -1.0f;
            }

            if (SceneManager.GetActiveScene().name != "Level 10 (Final Stage)")
            {
                if (transform.position.y <= -1.5 || gameObject.transform.childCount == 0)
                {
                    reinforcements.SetActive(true);
                }
            }
            else
            {
                if (gameObject.transform.childCount == 0)
                {
                    reinforcements.SetActive(true);
                }
            }
            
        }
    }
}