using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueOrPauseGame();
        }
    }

    public void ContinueOrPauseGame() 
    {
        isPaused = isPaused ? false : true;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }

    public void Exit()
    {
        GameObject t = GameObject.Find("Tod");
        if (t != null)
        {
            t.GetComponent<NovelIdea>().resetTime();
        }
        ContinueOrPauseGame();
        string name = "MainMenuScene";
        SceneManager.LoadScene(name);
    }
}
