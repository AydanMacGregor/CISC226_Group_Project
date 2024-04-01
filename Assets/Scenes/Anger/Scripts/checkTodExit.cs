using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTodExit : MonoBehaviour
{
    private GameObject con;
    private int num;
    void Start()
    {
        con = GameObject.FindWithTag("RoomController");
        if (this.name == "RoomOne" || this.name == "RoomOne (1)")
        {
            num = 0;
        }
        else if (this.name == "RoomTwo" || this.name == "RoomTwo (1)")
        {
            num = 1;
        }
        else if (this.name == "RoomThree")
        {
            num = 2;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Tod")
        {
            con.GetComponent<RoomControl>().Block(num);
        }
        
    }
}
