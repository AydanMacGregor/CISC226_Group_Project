using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findTod : MonoBehaviour
{
    private GameObject tod;
    private Vector3 todDir;
    // Start is called before the first frame update
    void Start()
    {
        tod = GameObject.Find("Tod");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(tod.transform.position, this.transform.position) > 2f)
        {
            todDir = (tod.transform.position - this.transform.position).normalized;
            transform.position += todDir * 3 * Time.deltaTime;
        }
    }
}
