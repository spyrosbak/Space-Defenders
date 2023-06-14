using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject chasingShips;
    [SerializeField] private Transform[] spawnPlaces;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SavedScore"))
        {
            PlayerPrefs.DeleteKey("SavedScore");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateChase", 1f, 5f);
    }

    private void InstantiateChase()
    {
        Instantiate(chasingShips, spawnPlaces[Random.Range(0, 3)]);
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif

        #if UNITY_WEBGL
                //Application.OpenURL("about:blank");
        #endif
    }
}