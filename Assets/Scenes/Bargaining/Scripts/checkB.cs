using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkB : MonoBehaviour
{
    public GameObject bt;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Tod")
        {
            Instantiate(bt, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
