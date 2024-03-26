using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string prevScene = "";
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
