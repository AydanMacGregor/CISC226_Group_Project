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

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
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
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<animationMovement>().UnBeam();
        StartCoroutine(BackToIdle());
    }

    IEnumerator BackToIdle()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<animationMovement>().Idle();
    }

    // New edit
    IEnumerable Charge()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<bossMovement>().chargeFlag = true;
        gameObject.GetComponent<animationMovement>().Charge();
        StartCoroutine(MoveTowardsTod());

    }

    IEnumerable MoveTowardsTod()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(MoveAwayTod());
    }

    IEnumerable MoveAwayTod()
    {
        gameObject.GetComponent<animationMovement>().UnCharge();
        gameObject.GetComponent<bossMovement>().isMovingBack = true;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<bossMovement>().chargeFlag = false;
        gameObject.GetComponent<bossMovement>().isMovingBack = false;

    }
}
