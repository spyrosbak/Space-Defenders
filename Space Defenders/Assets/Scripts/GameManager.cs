using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            }
            else
            {
                ResumeGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state != GameState.PAUSED)
            {
                PauseGame();
                //enable quit panel
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
}