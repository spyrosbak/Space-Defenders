using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileSample : MonoBehaviour
{
    private float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        if (transform.position.x >= 12 || transform.position.x <= -12 || transform.position.y >= 8 || transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }
}