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
        this.GetComponent<BMovement>().touchingTod = false;
    }

    IEnumerator screechAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(soundwave, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
    }
}
