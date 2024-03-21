using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationD : MonoBehaviour
{
    public Animator an;

    public void chooseAn(int i)
    {
        if (i == 0)
        {
            an.Play("stressballS");
        }
        else if (i == 1)
        {
            an.Play("armyofd");
        }
    }
}
