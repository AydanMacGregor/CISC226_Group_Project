using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAttack : MonoBehaviour
{
    public GameObject soundwave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attackChoice(short n)
    {
        switch (n){
            case 0:
                StartCoroutine(biteAttackDelay());
                break;
            case 1:
                StartCoroutine(screechAttackDelay());
                break;
            case 2:
                break;
        }
        
    }

    IEnumerator biteAttackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(biteAttack());
    }
    IEnumerator screechAttackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(screechAttack());
    }

    IEnumerator biteAttack()
    {
        this.GetComponent<BMovement>().isBiting = true;
        yield return new WaitForSeconds(2f);
        this.GetComponent<BMovement>().isBiting = false;
    }

    IEnumerator screechAttack()
    {
        this.GetComponent<BMovement>().isScreeching = true;
        yield return new WaitForSeconds(0.5f);
        Instantiate(soundwave, this.transform.position, Quaternion.identity);
        this.GetComponent<BMovement>().isScreeching = false;
    }
}
