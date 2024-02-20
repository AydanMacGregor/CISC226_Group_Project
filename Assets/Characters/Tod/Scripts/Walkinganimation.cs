using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkinganimation : MonoBehaviour
{
    public Animator an;
    Vector2 dir;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        dir = gameObject.GetComponent<movement>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        dir = gameObject.GetComponent<movement>().direction;
        if (rb.velocity == Vector2.zero)
        {
            an.Play("TodIdle");
        }
        else if (dir.x > 0)
        {
            an.Play("Walking_Right");
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x < 0)
        {
            an.Play("Walking_Right");
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.y > 0)
        {
            an.Play("Walking_Up");
        }
        else if (dir.y < 0)
        {
            an.Play("Walking_Right");
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
