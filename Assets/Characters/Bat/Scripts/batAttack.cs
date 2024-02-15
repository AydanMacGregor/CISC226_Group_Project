using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(biteAttack());
    }

    IEnumerator biteAttack()
    {
        // lunge towards tod
        
    }
}
