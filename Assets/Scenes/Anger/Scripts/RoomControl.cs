using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    public GameObject TodBlocker;
    private List<GameObject> blockers = new List<GameObject>();
    private bool checkEn = false;
    private int numGameObjects;
    private int current;
    private int[] numOfEn = {8, 5, 9};
    private GameObject[] rooms;

    // Start is called before the first frame update
    public void Block(int n)
    {
        checkEn = true;
        switch(n)
        {
            case 0:
                roomone();
                rooms = GameObject.FindGameObjectsWithTag("RoomOne");
                break;
            case 1:
                roomtwo();
                rooms = GameObject.FindGameObjectsWithTag("RoomTwo");
                break;
            case 2:
                roomthree();
                rooms = GameObject.FindGameObjectsWithTag("RoomThree");
                break;
        }
        current = n;
        foreach (GameObject i in rooms)
        {
            Destroy(i);
        }
    }

    void Update() 
    {
        if (checkEn)
        {
            int check = getEnemies();
            if ((numGameObjects - check) == numOfEn[current])
            {
                checkEn = false;
                foreach (GameObject i in blockers)
                {
                    Destroy(i);
                }
                blockers.Clear();
            }
        }
    }

    public void addEn()
    {
        if (checkEn)
        {
            numOfEn[current] += 1;
            numGameObjects += 1;
        }
    }

    void roomone()
    {
        GameObject one = Instantiate(TodBlocker, new Vector3(24.5f, 11.5f, 0f), Quaternion.identity);
        GameObject two = Instantiate(TodBlocker, new Vector3(9.5f, 25.5f, 0f), Quaternion.identity);

        two.transform.Rotate(0, 0, 90);
        GameObject three = Instantiate(TodBlocker, new Vector3(24.5f, 29.5f, 0f), Quaternion.identity);

        blockers.Add(one);
        blockers.Add(two);
        blockers.Add(three);

        numGameObjects = getEnemies();
    }

    void roomtwo()
    {
        GameObject one = Instantiate(TodBlocker, new Vector3(0.5f, 11.5f, 0f), Quaternion.identity);
        GameObject two = Instantiate(TodBlocker, new Vector3(9.5f, 25.5f, 0f), Quaternion.identity);

        two.transform.Rotate(0, 0, 90);

        blockers.Add(one);
        blockers.Add(two);

        numGameObjects = getEnemies();
    }

    void roomthree()
    {
        GameObject one = Instantiate(TodBlocker, new Vector3(24.5f, 29.5f, 0f), Quaternion.identity);
        GameObject two = Instantiate(TodBlocker, new Vector3(9.5f, 33.5f, 0f), Quaternion.identity);
        two.transform.Rotate(0, 0, 90);

        blockers.Add(one);
        blockers.Add(two);

        numGameObjects = getEnemies();
    }

    int getEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Soul").Length + GameObject.FindGameObjectsWithTag("Bat").Length + GameObject.FindGameObjectsWithTag("Angel").Length;
    }
}
