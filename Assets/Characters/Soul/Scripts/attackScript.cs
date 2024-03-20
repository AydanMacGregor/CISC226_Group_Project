using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    public GameObject eyeball;
   
    public void attackChoice(int n)
    {
        switch (n){
            case 0:
                StartCoroutine(DelayEyeball());
                break;
            case 1:
                StartCoroutine(DelayCharge());
                break;
        }
        
    }

    IEnumerator DelayEyeball()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(eyeball, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
    }

    IEnumerator DelayCharge()
    {
        this.GetComponent<Movement>().isAttacking = true;
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<Movement>().isCharging = true;
        StartCoroutine(MoveTowardsTod());
    }

    IEnumerator MoveTowardsTod()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(MoveAwayTod());
    }

    public IEnumerator MoveAwayTod()
    {
        this.GetComponent<Animator>().Play("UnCharge");
        this.GetComponent<Movement>().isMovingBack = true;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Movement>().isCharging = false;
        this.GetComponent<Movement>().isMovingBack = false;
        this.GetComponent<Movement>().isAttacking = false;
    }
}
