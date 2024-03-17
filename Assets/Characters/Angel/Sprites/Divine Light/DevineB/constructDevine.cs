using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructDevine : MonoBehaviour
{
    public GameObject devineLine;
    private Transform t;
    
    void Start()
    {
        Destroy(this.gameObject, 1f);
        t = this.transform;
        for (float i = 0.7f; i < 30; i+=0.7f)
        {
            GameObject up = GameObject.Instantiate(devineLine, new Vector3(t.position.x, t.position.y + i, -2), Quaternion.identity);
            GameObject down = GameObject.Instantiate(devineLine, new Vector3(t.position.x, t.position.y - i, -2), Quaternion.identity);
            GameObject right = GameObject.Instantiate(devineLine, new Vector3(t.position.x + i, t.position.y, -2), Quaternion.identity);
            right.GetComponent<Transform>().Rotate(0,0,90);
            GameObject left = GameObject.Instantiate(devineLine, new Vector3(t.position.x - i, t.position.y, -2), Quaternion.identity);
            left.GetComponent<Transform>().Rotate(0,0,90);
        }
    }

}

