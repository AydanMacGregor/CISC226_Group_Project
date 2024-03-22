using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking : MonoBehaviour
{
    public GameObject sb;
    public Animator a;

    public GameObject soul;
    public GameObject bat;
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
        yield return new WaitForSeconds(1f);
        Instantiate(sb, this.transform.position, Quaternion.identity);
        a.Play("unstressball");
    }

    IEnumerator AODDelay()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            Vector3 ran = new Vector3(Random.Range(-3,3), Random.Range(-3,3), 0f);
            Vector2 Dir = ((Vector2) this.transform.position + (Vector2)ran - (Vector2) this.transform.position).normalized;
            RaycastHit2D cast = Physics2D.Raycast(this.transform.position, Dir, 3f, LayerMask.GetMask("Confinment"));
            while (cast.collider != null && cast.collider.name == "Confinment")
            {
                ran = new Vector3(Random.Range(-3,3), Random.Range(-3,3), 0f);
                Dir = ((Vector2) this.transform.position + (Vector2)ran - (Vector2) this.transform.position).normalized;
                cast = Physics2D.Raycast(this.transform.position, Dir, 3f, LayerMask.GetMask("Confinment", "InnerWall"));
            }
            int r = Random.Range(0,2);
            if (r == 0)
            {
                Instantiate(soul, this.transform.position + ran, Quaternion.identity);
            }
            else
            {
                Instantiate(bat, this.transform.position + ran, Quaternion.identity);
            }
        }
        StartCoroutine(AODEnd());
    }

    IEnumerator AODEnd()
    {
        yield return new WaitForSeconds(0.3f);
        a.Play("unArmy");
    }

    IEnumerator DarkSwipe()
    {
        GameObject tod = GameObject.Find("Tod");
        Vector3 location = (tod.transform.position - this.transform.position).normalized;
        float angleDegrees = Mathf.Atan2(location.x, location.z);
        int finalAngle = (int)angleDegrees;
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
