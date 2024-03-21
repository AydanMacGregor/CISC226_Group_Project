using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainAttack : MonoBehaviour
{
    public GameObject soundwave;
    public GameObject extend;
    private GameObject[] extendLines;
    public Animator an;

    public void StartAttack(int n)
    {
        switch (n)
        {
            case 0:
                StartCoroutine(Clap());
                break;
            case 1:
                StartCoroutine(ExtendA());
                break;
        }

    }

    IEnumerator Clap()
    {
        gameObject.GetComponent<BargainMovement>().isClaping = true;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<BargainAnimation>().ChainClap();
        Instantiate(soundwave, this.transform.position, Quaternion.identity);
        gameObject.GetComponent<BargainMovement>().isClaping = false;
    }

    IEnumerator ExtendA()
    {
        gameObject.GetComponent<BargainAnimation>().ExtendArms();
        yield return new WaitForSeconds(0.5f);
        Instantiate(extend, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        extendLines = GameObject.FindGameObjectsWithTag("BeamLine");
        foreach (GameObject el in extendLines)
        {
            Destroy(el);
        }
        Destroy(GameObject.FindWithTag("Beam"));
        StartCoroutine(EndExtend());
    }

    IEnumerator EndExtend()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BargainAnimation>().UnExtend();
        StartCoroutine(BackToIdle());
    }

    IEnumerator BackToIdle()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BargainAnimation>().Idle();
    }

}