using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image[] livesIcons; 

    private float verticalPos;
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        verticalPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, verticalPos);

        if (gameObject.transform.position.x <= -8f)
        {
            gameObject.transform.position = new Vector2(-8f, verticalPos);
        }
        else if (gameObject.transform.position.x >= 8f)
        {
            gameObject.transform.position = new Vector2(8f, verticalPos);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);

            lives--;
            Destroy(livesIcons[lives]);

            if(lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}