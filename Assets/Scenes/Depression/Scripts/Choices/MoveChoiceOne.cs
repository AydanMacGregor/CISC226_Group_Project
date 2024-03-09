using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChoiceOne : MonoBehaviour
{
    int path = 0;
    public GameObject bt;
    bool chosen = false;
    private int[] numOfEn = {4, 5, 10, 6};
    private int numGameObjects;

    void OnTriggerExit2D(Collider2D other)
    {
        chosen = true;
    }

    void Update()
    {
        if (chosen)
        {
            int check = GameObject.FindGameObjectsWithTag("Soul").Length + GameObject.FindGameObjectsWithTag("Bat").Length;
            if ((numGameObjects - check) == numOfEn[path])
            {
                path++;
                moveBlockers();
            }
        }
    }

    void moveBlockers()
    {
        GameObject th;
        switch(path)
        {
            case 0:
                th = Instantiate(bt, new Vector3(11.5f, 37.5f, 0f), Quaternion.identity);
                th.transform.Rotate(0, 0, 90);
                break;
            case 1:
                Instantiate(bt, new Vector3(11.5f, 37.5f, 0f), Quaternion.identity);
                break;
            case 2:
                th = Instantiate(bt, new Vector3(11.5f, 37.5f, 0f), Quaternion.identity);
                th.transform.Rotate(0, 0, 90);
                break;
            case 3:
                th = Instantiate(bt, new Vector3(11.5f, 37.5f, 0f), Quaternion.identity);
                th.transform.Rotate(0, 0, 90);
                break;
        }
        numGameObjects = GameObject.FindGameObjectsWithTag("Soul").Length + GameObject.FindGameObjectsWithTag("Bat").Length;
    }
}
