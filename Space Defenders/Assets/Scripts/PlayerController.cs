using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalPos;

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
}