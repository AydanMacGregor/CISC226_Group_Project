using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkinganimation : MonoBehaviour
{
    public Animator an;
    Vector2 dir;
    public Rigidbody2D rb;
    private bool sh;
    private bool slash;
    private string animationChoice;
    public Sprite idle;
    public SpriteRenderer sr;
    
    void Start()
    {
        dir = gameObject.GetComponent<movement>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        sh = gameObject.GetComponent<AttackDefend>().s;
        slash = gameObject.GetComponent<AttackDefend>().sl;
        if (!sh)
        {
            dir = gameObject.GetComponent<movement>().direction;
            if (rb.velocity == Vector2.zero)
            {
                if (slash)
                {
                    sr.sprite = idle;
                }
                else
                {
                    an.Play("TodIdle");
                }
            }
            else if (dir.x > 0)
            {
                animationChoice = slash ? "Walking_Right_NS" : "Walking_Right";
                an.Play(animationChoice);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (dir.x < 0)
            {
                animationChoice = slash ? "Walking_Right_NS" : "Walking_Right";
                an.Play(animationChoice);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (dir.y > 0)
            {
                an.Play("Walking_Up");
            }
            else if (dir.y < 0)
            {
                animationChoice = slash ? "Walking_Right_NS" : "Walking_Right";
                an.Play(animationChoice);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        
    }
}
