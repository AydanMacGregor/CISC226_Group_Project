using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkinganimation : MonoBehaviour
{
    public Animator an;
    Vector2 dir;
    public Rigidbody2D rb;
    private bool sh;
    private bool slash = true;
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
                    an.Play("TodIdle_NS");;
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
                animationChoice = slash ? "Walking_Up_NS" : "Walking_Up";
                an.Play(animationChoice);
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
