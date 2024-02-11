using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    public GameObject eyeball;
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
                StartCoroutine(DelayEyeball());
                break;
            case 1:
                StartCoroutine(DelayCharge());
                break;
            case 2:
                // code block
                break;
        }
        
    }

    IEnumerator DelayEyeball()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(eyeball, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
    }

    IEnumerator DelayCharge()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(MoveTowardsTod());
    }

    IEnumerator MoveTowardsTod()
    {
        this.GetComponent<Movement>().isCharging = true;
        yield return new WaitForSeconds(2f);
        this.GetComponent<Movement>().isCharging = false;
        this.GetComponent<Movement>().touchingTod = false;
        this.GetComponent<Animator>().Play("UnCharge");
    }
}
