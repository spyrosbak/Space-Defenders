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
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject quitPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject enemyReinforcements;

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

        if(state == GameState.LOSE)
        {
            losePanel.SetActive(true);
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
        Time.timeScale = 0;
        state = GameState.PAUSED;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        state = GameState.START;
    }

    public void QuitGame()
    {

    }

    public void Win()
    {
        state = GameState.WIN;
        winPanel.SetActive(true);
        winPanel.transform.GetChild(2).GetComponent<Image>().fillAmount += 0.2f * Time.deltaTime;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}