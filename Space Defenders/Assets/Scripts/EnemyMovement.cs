using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject reinforcements;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (transform.position.x >= 4f || transform.position.x <= -4f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
            moveSpeed *= -1.05f;
        }

        if(transform.position.y <= -1.5)
        {
            reinforcements.SetActive(true);
        }
    }
}