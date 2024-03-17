using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAttack : MonoBehaviour
{
    public GameObject soul;
    public GameObject bat;
    public Animator an;
    public GameObject dl;

    public void attackChoice(int n)
    {
        switch (n){
            case 0:
                StartCoroutine(DevineDelay());
                break;
            case 1:
                StartCoroutine(SummonAttackDelay());
                break;
        }
    }

    IEnumerator DevineDelay()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<moveAngel>().isDevine = true;
        StartCoroutine(devineAttack());
    }

    IEnumerator devineAttack()
    {
        Instantiate(dl, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(StopAttack());
    }

    public IEnumerator StopAttack()
    {
        an.Play("UnDevine");
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<moveAngel>().isDevine = false;
    }

    IEnumerator SummonAttackDelay()
    {
        this.GetComponent<moveAngel>().isDevine = true;
        yield return new WaitForSeconds(0.2f);
        int r = Random.Range(0,2);
        if (r == 0)
        {
            Instantiate(soul, this.transform.position + new Vector3(Random.Range(-3,3), Random.Range(-3,3), 1f), Quaternion.identity);
        }
        else
        {
            Instantiate(bat, this.transform.position + new Vector3(Random.Range(-3,3), Random.Range(-3,3), 1f), Quaternion.identity);
        }
        this.GetComponent<moveAngel>().isDevine = false;
    }
}
