using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforcments : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= -15f)
        {
            transform.position = new Vector2(15.0f, transform.position.y - 0.5f);
            moveSpeed *= 1.15f;
        }
    }
}