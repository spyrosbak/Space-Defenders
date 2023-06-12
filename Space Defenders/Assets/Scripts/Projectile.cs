using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject pointsText;
    private PlayerController playerController;
    private GameManager gameManager;
    private float moveSpeed = 5.0f;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        if(transform.position.x >= 12 || transform.position.x <= -12 || transform.position.y >= 8 || transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Animator>().Play(collision.gameObject.name + "Destroy");
            collision.gameObject.GetComponent<AudioSource>().Play();

            int killPoints = 1 * collision.gameObject.GetComponent<EnemyAttack>().killPoints;
            playerController.AddPoints(killPoints);

            gameManager.pointsText.GetComponent<Animator>().SetTrigger("Hit");
            gameManager.pointsText.GetComponent<TextMeshProUGUI>().text = "x" + killPoints +"P";

            Destroy(gameObject);
        }
    }
}