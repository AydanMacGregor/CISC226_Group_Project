using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalCheck : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Tod")
        {
            GameObject b = GameObject.Find("FloorController");
            GameObject t = GameObject.Find("Tod");
            b.GetComponent<control>().finalBlocker = true;
            t.GetComponent<movement>().finalScene = true;
            Destroy(this.gameObject);
        }
    }
}
