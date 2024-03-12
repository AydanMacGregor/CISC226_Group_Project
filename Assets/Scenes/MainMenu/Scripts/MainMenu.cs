using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame() {

        Debug.Log("Pressed Load");
        string name = "DenialScene";
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        Debug.Log("Pressed Exit");
        Application.Quit();

    }
}
