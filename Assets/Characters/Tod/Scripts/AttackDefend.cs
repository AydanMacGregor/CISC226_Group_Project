using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefend : MonoBehaviour
{
    public GameObject slash;
    public GameObject tod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(slash, new Vector3(tod.transform.position.x + (0.5f * Input.GetAxis("Horizontal")), tod.transform.position.y, tod.transform.position.z), Quaternion.identity);
        }
    }
}
