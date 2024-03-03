using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Random.insideUnitCircle.normalized;
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += dir * 3f * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.name != "Bat" && other.gameObject.name != "BatBaby(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
