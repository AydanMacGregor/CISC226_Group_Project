using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTod : MonoBehaviour
{
    public GameObject beam;
    private GameObject[] beamLines;
    

    public void StartAttack()
    {
        StartCoroutine(Attack());
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
}
