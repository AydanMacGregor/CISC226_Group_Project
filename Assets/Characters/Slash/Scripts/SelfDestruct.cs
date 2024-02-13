using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private GameObject pos;
    public Transform tf;
    private Vector2 dir;
    void Awake()
    {
        pos = GameObject.FindWithTag("Tod");
        dir = pos.GetComponent<movement>().direction;
        if (dir.x < 0)
        {
            tf.Rotate(0,180,90);
        }
        else if (dir.x > 0)
        {
            tf.Rotate(0,0,90);
        }
        if (dir.y < 0)
        {
            tf.Rotate(0,0,0);
        }
        else if (dir.y > 0)
        {
            tf.Rotate(0,0,180);
        }
    }
    
    void Start()
    {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    void Update()
    {
        transform.position = new Vector3(pos.transform.position.x + (0.5f * dir.x), pos.transform.position.y + (0.5f * dir.y), pos.transform.position.z);
    }
}
