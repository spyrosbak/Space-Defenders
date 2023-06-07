using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChaseScenario : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, Random.Range(0.5f, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Random.Range(1f, 5f) * Time.deltaTime);
        
        if(gameObject.transform.position.x >= 12 || gameObject.transform.position.x <= -12 || gameObject.transform.position.y >= 8 || gameObject.transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, gameObject.transform.GetChild(0).transform.position, gameObject.transform.GetChild(0).transform.rotation);
    }
}