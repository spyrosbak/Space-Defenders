using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        START,
        PAUSED,
        WIN,
        LOSE,
    }

    public GameState state;

    [Header("UI")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject quitPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject enemyReinforcements;


    [Header("Audio")]
    [SerializeField] private AudioSource pauseSound;
    [SerializeField] private AudioSource victorySound;
    [SerializeField] private AudioSource gameOverSound;

    private bool won = false;
    private bool lost = false;

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.START;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (state != GameState.PAUSED)
            {
                PauseGame();
                pausePanel.SetActive(true);
            }
            else
            {
                ResumeGame();
                pausePanel.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state != GameState.PAUSED)
            {
                PauseGame();
                quitPanel.SetActive(true);
            }
        }

        if(state == GameState.LOSE && lost == false)
        {
            Lost();
        }

        if(enemies.transform.childCount == 0 && enemyReinforcements.transform.childCount == 0)
        {
            Win();

            if(winPanel.transform.GetChild(2).GetComponent<Image>().fillAmount == 1.0f)
            {
                //change scene
            }
        }
    }

    public void PauseGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Pause();
        pauseSound.Play();
        Time.timeScale = 0;
        state = GameState.PAUSED;
    }

    public void ResumeGame()
    {
        pauseSound.Play();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        state = GameState.START;
    }

    public void QuitGame()
    {

    }

    public void Win()
    {
        if(won == false)
        {
            state = GameState.WIN;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
            victorySound.Play();
            winPanel.SetActive(true);
            won = true;
        }

        if (winPanel.transform.GetChild(2).GetComponent<Image>())
        {
            winPanel.transform.GetChild(2).GetComponent<Image>().fillAmount += 0.5f * Time.deltaTime;
        }
    }

    public void Lost()
    {
        lost = true;
        losePanel.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
        gameOverSound.Play();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}