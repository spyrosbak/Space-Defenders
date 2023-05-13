using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);

        if (gameObject.transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}