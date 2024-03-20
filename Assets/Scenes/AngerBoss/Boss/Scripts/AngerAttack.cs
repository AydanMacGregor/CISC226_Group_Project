using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAttack : MonoBehaviour
{
    public void StartAttack(int n)
    {
        switch (n)
        {
            case 0:
                StartCoroutine(Pong());
                break;
            case 1:
                StartCoroutine(Expand());
                break;
        }

    }

    IEnumerator Pong()
    {
        gameObject.GetComponent<AngerAnimation>().FirePong();
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Expand()
    {
        gameObject.GetComponent<AngerAnimation>().FlameExpand();
        yield return new WaitForSeconds(1f);
    }
}
