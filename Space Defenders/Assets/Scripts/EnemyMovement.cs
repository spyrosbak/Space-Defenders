using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (transform.position.x >= 8f || transform.position.x <= -8f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            moveSpeed *= -1;
        }
    }
}