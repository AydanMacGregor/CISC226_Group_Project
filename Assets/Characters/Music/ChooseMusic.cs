using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMusic : MonoBehaviour
{
    public AudioSource audioMain;
    public AudioSource audioLevel;
    public AudioSource audioBoss;
    public AudioClip bm;
    public AudioClip mm;
    public AudioClip lvl;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioLevel.Stop();
        audioBoss.Stop();
        audioMain.Play();

    }

    private void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string check = SceneManager.GetActiveScene().name;
        if (check == "MainMenuScene")
        {
            audioLevel.Stop();
            audioBoss.Stop();
            audioMain.Play();
        }
        else if (check.Contains("Boss"))
        {
            audioLevel.Stop();
            audioBoss.Play();
            audioMain.Stop();
        }
        else
        {
            audioLevel.Play();
            audioBoss.Stop();
            audioMain.Stop();
        }
    }
}
