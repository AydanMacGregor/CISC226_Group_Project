using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAnimation : MonoBehaviour
{
    public Animator an;
    public Sprite Anger;
    public Sprite Flame;
    public Sprite Expand;
    private Vector3 dir;
    public SpriteRenderer sr;

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    void Flip()
    {
        dir = this.GetComponent<AngerMovement>().direction;
        if (dir.x < 0)
        {
            sr.flipX = true;
        }
        else if (dir.x > 0)
        {
            sr.flipX = false;
        }
    }

    public void FirePong()
    {
        an.Play("FirePong");
    }

    public void FlameExpand()
    {
        an.Play("FlameExpand");
    }

    public void Idle()
    {
        an.Play("Idle");
    }
}
