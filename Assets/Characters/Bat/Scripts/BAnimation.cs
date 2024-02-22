using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAnimation : MonoBehaviour
{
    public Animator an;
    private string[] attackAnimations = {"Bite_Anim", "Screech_Anim"};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseAttack(int n)
    {
        an.Play(attackAnimations[n]);
    }
}
