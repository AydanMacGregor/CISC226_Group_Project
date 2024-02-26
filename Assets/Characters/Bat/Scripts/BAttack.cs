using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAttack : MonoBehaviour
{
    public GameObject soundwave;
    public Animator an;

    public void attackChoice(int n)
    {
        switch (n){
            case 0:
                StartCoroutine(biteAttackDelay());
                break;
            case 1:
                StartCoroutine(screechAttackDelay());
                break;
        }
        
    }

    IEnumerator biteAttackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<BMovement>().isBiting = true;
        StartCoroutine(biteAttack());
    }
    

    IEnumerator biteAttack()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(MoveAway());
    }

    public IEnumerator MoveAway()
    {
        an.Play("UnDash_anim");
        this.GetComponent<BMovement>().isMovingBack = true;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<BMovement>().isMovingBack = false;
        this.GetComponent<BMovement>().isBiting = false;
    }

    IEnumerator screechAttackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(screechAttack());
    }

    IEnumerator screechAttack()
    {
        this.GetComponent<BMovement>().isScreeching = true;
        yield return new WaitForSeconds(0.5f);
        Instantiate(soundwave, this.transform.position, Quaternion.identity);
        this.GetComponent<BMovement>().isScreeching = false;
    }
}
