using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    public Animator an;
    private string[] attackAnimations = {"ThrowEye", "Charge", "ProjectileThrow"};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseAttack(short n)
    {
        an.Play(attackAnimations[n]);
    }
}
