using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAnimation : MonoBehaviour
{
    public Animator an;
    private string[] attackAnimations = {"DevineLight", "summonen"};

    public void chooseAttack(int n)
    {
        an.Play(attackAnimations[n]);
    }
}
