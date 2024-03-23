using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainAnimation : MonoBehaviour
{
    public Animator an;
    public Sprite Bargaining;
    public Sprite Clap;
    public Sprite Extend;
    private Vector3 dir;
    public SpriteRenderer sr;

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    void Flip()
    {
        dir = this.GetComponent<BargainMovement>().direction;
        if (dir.x < 0)
        {
            sr.flipX = true;
        }
        else if (dir.x > 0)
        {
            sr.flipX = false;
        }
    }

    public void ChainClap()
    {
        an.Play("ChainClap");
    }

    public void ChainExtend()
    {
        an.Play("ChainExtend");
    }

    public void UnExtend()
    {
        an.Play("ChainUnExtend");
    }

    public void Idle()
    {
        an.Play("Idle");
    }

}
