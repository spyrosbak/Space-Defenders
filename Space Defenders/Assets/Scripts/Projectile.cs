using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private PlayerController playerController;
    private float moveSpeed = 5.0f;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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

            playerController.AddPoints();

            Destroy(gameObject);
        }
    }
}