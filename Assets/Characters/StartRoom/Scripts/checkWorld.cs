using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkWorld : MonoBehaviour
{
    public Sprite blue;
    public Sprite green;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "DepressionScene")
        {
            this.GetComponent<SpriteRenderer>().sprite = blue;
        }
        else if (SceneManager.GetActiveScene().name == "BargainingScene")
        {
            this.GetComponent<SpriteRenderer>().sprite = green;
        }
    }
}
