using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationMovement : MonoBehaviour
{
    public Animator an;
    public Sprite idleHappy;
    public Sprite idleSad;
    private Vector3 dir;
    public SpriteRenderer sr;
    
    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    void Flip()
    {
        dir = this.GetComponent<bossMovement>().direction;
        if (dir.x < 0)
        {
            sr.flipX = true;
        }
        else if (dir.x > 0)
        {
            sr.flipX = false;
        }
    }

    public void Beam()
    {
        an.Play("MaskChangeEye");
    }

    public void UnBeam()
    {
        an.Play("UnMaskChangeEye");
    }

    public void Idle()
    {
        an.Play("Idle");
    }

    // New edit
    public void Charge()
    {
        an.Play("MaskChangeSad");
    }

    public void UnCharge()
    {
        an.Play("MaskChangeHappy");
    }
}
