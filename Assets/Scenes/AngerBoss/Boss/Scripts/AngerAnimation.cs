using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAnimation : MonoBehaviour
{
    public Animator an;
    private Vector3 dir;
    public SpriteRenderer sr;
    private float timer = 0.25f;

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    void Flip()
    {
        if (timer < 0)
        {
            timer = 0.25f;
            sr.flipX = sr.flipX ? false : true;
        }
        timer -= Time.deltaTime;
    }

    public void FirePong()
    {
        an.Play("FirePong");
    }

    public void UnFirePong()
    {
        an.Play("UnFirePong");
    }

    public void UnFlameExpand()
    {
        an.Play("UnFlameExpand");
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
