using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        yield return new WaitForSeconds(0.7f);
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
        this.GetComponent<moveAngel>().isAttacking = false;
    }

    IEnumerator SummonAttackDelay()
    {
        if (SceneManager.GetActiveScene().name == "AngerScene")
        {
            GameObject c = GameObject.Find("Controller");
            c.GetComponent<RoomControl>().addEn();
        }
        else if (SceneManager.GetActiveScene().name == "DepressionScene")
        {
            GameObject cOne = GameObject.Find("ChoiceOne");
            GameObject cTwo = GameObject.Find("ChoiceTwo");
            cOne.GetComponent<RoomControl>().addEn();
            cTwo.GetComponent<RoomControl>().addEn();
        }
        this.GetComponent<moveAngel>().isDevine = true;
        yield return new WaitForSeconds(0.7f);
        Vector3 ran = new Vector3(Random.Range(-3,3), Random.Range(-3,3), 0f);
        Vector2 Dir = ((Vector2) this.transform.position + (Vector2)ran - (Vector2) this.transform.position).normalized;
        RaycastHit2D cast = Physics2D.Raycast(this.transform.position, Dir, 3f, LayerMask.GetMask("Confinment", "InnerWall"));
        while (cast.collider != null && (cast.collider.name == "Confinment" || cast.collider.name == "InnerWall"))
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
        this.GetComponent<moveAngel>().isDevine = false;
        this.GetComponent<moveAngel>().isAttacking = false;
    }
}
