using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChoiceOne : MonoBehaviour
{
    int path = 0;
    public GameObject bt;
    bool chosen = false;
    private int[] numOfEn = {4, 4, 10, 7};
    private int numGameObjects;
    private GameObject th;
    private bool onceOver = true;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Tod")
        {
            if (onceOver)
            {
                onceOver = false;
                chosen = true;
                th = Instantiate(bt, new Vector3(11.5f, 37.5f, 0f), Quaternion.identity);
                moveBlockers();
            }
        }
    }

    void Update()
    {
        if (chosen)
        {
            int check = GameObject.FindGameObjectsWithTag("Soul").Length + GameObject.FindGameObjectsWithTag("Bat").Length + GameObject.FindGameObjectsWithTag("Angel").Length;
            if ((numGameObjects - check) == numOfEn[path])
            {
                path++;
                moveBlockers();
            }
            if (path == 4)
            {
                Destroy(th);
                Destroy(this);
            }
        }
    }

    public void addEn()
    {
        if (chosen)
        {
            numOfEn[path] += 1;
            numGameObjects += 1;
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
                th.transform.position =  new Vector3(7.5f, 25.5f, 0f);
                th.transform.Rotate(0, 0, -90);
                break;
            case 2:
                th.transform.position =  new Vector3(32.5f, 38.5f, 0f);
                th.transform.Rotate(0, 0, 90);
                break;
            case 3:
                th.transform.position =  new Vector3(20.5f, 11.5f, 0f);
                break;
        }
        numGameObjects = GameObject.FindGameObjectsWithTag("Soul").Length + GameObject.FindGameObjectsWithTag("Bat").Length + GameObject.FindGameObjectsWithTag("Angel").Length;
    }
}
