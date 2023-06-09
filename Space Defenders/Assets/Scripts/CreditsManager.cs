using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 1600)
        {
            transform.Translate(Vector2.up * 50 * Time.deltaTime);
        }
        else
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().volume-=0.2f * Time.deltaTime;
            StartCoroutine(GoToHomeScreen());
        }
    }

    private IEnumerator GoToHomeScreen()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(0);
    }
}