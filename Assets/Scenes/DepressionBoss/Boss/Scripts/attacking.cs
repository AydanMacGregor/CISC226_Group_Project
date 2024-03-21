using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking : MonoBehaviour
{
    public void StartAttack(int n)
    {
        switch(n){
            case 0:
                StartCoroutine(StressBallDelay());
                break;
            case 1:
                StartCoroutine(AODDelay());
                break;
            case 2:
                StartCoroutine(DarkSwipe());
                break;
        }
    }

    IEnumerator StressBallDelay()
    {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator AODDelay()
    {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator DarkSwipe()
    {
        GameObject tod = GameObject.Find("Tod");
        Vector3 location = (tod.transform.position - this.transform.position).normalized;
        float angleDegrees = Mathf.Atan2(location.x, location.z);
        int finalAngle = (int)angleDegrees;
        Debug.Log(finalAngle);
        switch(finalAngle){
            case 0:
                if (location.y < 0)
                {
                    this.transform.GetChild(3).GetComponent<Animator>().Play("swipe");
                }   
                else
                {
                    this.transform.GetChild(2).GetComponent<Animator>().Play("swipe");
                }
                break;
            case -1:
                this.transform.GetChild(1).GetComponent<Animator>().Play("swipe");
                break;
            case 1:
                this.transform.GetChild(0).GetComponent<Animator>().Play("swipe");
                break;
        }
        yield return new WaitForSeconds(2f);
    }
}
