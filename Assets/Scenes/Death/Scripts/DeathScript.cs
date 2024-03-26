using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public void LoadGame() 
    {
        SceneManager.LoadScene(GameObject.Find("GameM").GetComponent<Manager>().prevScene);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
