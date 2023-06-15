using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] private Image cooldown;

    private GameManager gameManager;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            if(gameManager.state == GameManager.GameState.START)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
            }

            StartCoroutine(shootCooldown());
        }    
    }

    private IEnumerator shootCooldown()
    {
        cooldown.fillAmount = 0;
        canShoot = false;

        yield return new WaitForSeconds(0.75f);

        cooldown.fillAmount = 1;
        if (cooldown.fillAmount == 1f)
        {
            canShoot = true;
        }
    }
}