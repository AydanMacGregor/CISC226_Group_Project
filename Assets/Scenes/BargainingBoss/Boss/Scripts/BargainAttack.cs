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
        SpawnClap();
    }

    void SpawnClap()
    {
        gameObject.GetComponent<BargainAnimation>().ChainClap();
        Instantiate(soundwave, this.transform.position, Quaternion.identity);
        StartCoroutine(UnClap());
    }

    public IEnumerator UnClap()
    {
        gameObject.GetComponent<BargainMovement>().isMovingBack = true;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<BargainMovement>().isClaping = false;
        gameObject.GetComponent<BargainMovement>().isMovingBack = false;
    }

    IEnumerator ExtendA()
    {
        gameObject.GetComponent<BargainAnimation>().ExtendArms();
        yield return new WaitForSeconds(0.2f);
        Instantiate(extend, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<BargainAnimation>().UnExtend();
    }

    IEnumerator BackToIdle()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BargainAnimation>().Idle();
    }

}
