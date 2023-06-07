using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image[] livesIcons;
    [SerializeField] private Sprite[] mainIcon;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource shipDestroyed;

    private GameManager gameManager;
    private Animator mainShipaAnimator;
    private float verticalPos;
    private int lives = 3;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        verticalPos = transform.position.y;

        mainShipaAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.state == GameManager.GameState.START)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Enemy")
        {   
            Destroy(collision.collider.gameObject);
            shipDestroyed.Play();

            foreach (Image icon in livesIcons)
            {
                Destroy(icon);
            }
            
            Destroy(gameObject);
            gameManager.state = GameManager.GameState.LOSE;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            shipDestroyed.Play();

            lives--;
            gameObject.GetComponent<SpriteRenderer>().sprite = mainIcon[lives];
            Destroy(livesIcons[lives]);

            if (lives <= 0)
            {
                gameManager.state = GameManager.GameState.LOSE;
                mainShipaAnimator.enabled = true;
                mainShipaAnimator.SetTrigger("Destroy");
                shipDestroyed.Play();
            }
        }
    }

    public void AddPoints()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}