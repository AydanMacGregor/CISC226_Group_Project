using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTod : MonoBehaviour
{
    public GameObject beam;
    private GameObject[] beamLines;
    

    public void StartAttack(int n)
    {
        switch(n){
            case 0:
                StartCoroutine(Attack());
                break;
            case 1:
                StartCoroutine(Charge());
                break;
        }
    }


    public IEnumerator Attack()
    {
        gameObject.GetComponent<animationMovement>().Beam();
        yield return new WaitForSeconds(1f);
        StartCoroutine(BeamAttack());
    }

    IEnumerator BeamAttack()
    {
        Instantiate(beam, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        beamLines = GameObject.FindGameObjectsWithTag("BeamLine");
        foreach (GameObject bl in beamLines)
        {
            Destroy(bl);
        }
        Destroy(GameObject.FindWithTag("Beam"));
        StartCoroutine(EndAttack());
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<animationMovement>().UnBeam();
    }

    IEnumerator Charge()
    {
        gameObject.GetComponent<animationMovement>().Charge();
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<bossMovement>().chargeFlag = true;
        StartCoroutine(MoveTowardsTod());
    }

    IEnumerator MoveTowardsTod()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(MoveAwayTod());
    }

    public IEnumerator MoveAwayTod()
    {
        gameObject.GetComponent<animationMovement>().UnCharge();
        gameObject.GetComponent<bossMovement>().isMovingBack = true;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<bossMovement>().chargeFlag = false;
        gameObject.GetComponent<bossMovement>().isMovingBack = false;
        gameObject.GetComponent<bossMovement>().attackTime = 4f;
    }
}
