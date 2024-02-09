using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefend : MonoBehaviour
{
    public GameObject slash;
    public GameObject tod;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = tod.GetComponent<movement>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(slash, new Vector3(tod.transform.position.x + (0.5f * dir.x), tod.transform.position.y + (0.5f * dir.y), tod.transform.position.z), Quaternion.identity);
        }
    }
}
