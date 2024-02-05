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
        StartCoroutine(SelfDestroy());
        pos = GameObject.FindWithTag("Tod");
        dir = pos.GetComponent<movement>().direction;
        if (dir.x < 0)
        {
            tf.Rotate(0,0,180);
        }
        if (dir.y < 0)
        {
            tf.Rotate(0,0,-90);
        }
        else if (dir.y > 0)
        {
            tf.Rotate(0,0,90);
        }
    }
    
    void Update()
    {
        transform.position = new Vector3(pos.transform.position.x + (0.5f * dir.x), pos.transform.position.y + (0.5f * dir.y), pos.transform.position.z);
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
