using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAttack : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attackChoice(short n)
    {
        switch (n){
            case 0:
                StartCoroutine(AttackDelay());
                break;
            case 1:
                // code block
                break;
        }
        
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(biteAttack());
    }

    IEnumerator biteAttack()
    {
        this.GetComponent<BMovement>().isBiting = true;
        yield return new WaitForSeconds(2f);
        this.GetComponent<BMovement>().isBiting = false;
        this.GetComponent<BMovement>().touchingTod = false;
    }
}
