using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAnimation : MonoBehaviour
{
    public Animator an;

    public Rigidbody2D rb;
    private string[] attackAnimations = {"Screech_Anim", "Dash_anim"};
    public void chooseAttack(int n)
    {
        an.Play(attackAnimations[n]);
    }
}
