using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVehicle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            Destroy(gameObject);
        }       
    }
}