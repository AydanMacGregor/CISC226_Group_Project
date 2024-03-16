using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChoiceTwo : MonoBehaviour
{
    int path = 0;
    public GameObject bt;
    bool chosen = false;
    private int[] numOfEn = {8, 6};
    private int numGameObjects;
    private GameObject th;
    private bool onceOver = true;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Tod")
        {
            if (onceOver)
            {
                chosen = true;
                th = Instantiate(bt, new Vector3(39.5f, -0.5f, 0f), Quaternion.identity);
                moveBlockers();
            }
        }
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
            if (path == 2)
            {
                Destroy(th);
                Destroy(this);
            }
        }
    }

    void moveBlockers()
    {
        switch(path)
        {
            case 0:
                th.transform.Rotate(0, 0, 90);
                break;
            case 1:
                th.transform.position =  new Vector3(18.5f, 4.5f, 0f);
                th.transform.Rotate(0, 0, -90);
                break;
        }
        numGameObjects = GameObject.FindGameObjectsWithTag("Soul").Length + GameObject.FindGameObjectsWithTag("Bat").Length;
    }
}
