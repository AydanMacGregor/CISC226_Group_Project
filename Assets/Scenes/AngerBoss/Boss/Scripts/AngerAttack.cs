using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAttack : MonoBehaviour
{
    public List<GameObject> flames = new List<GameObject>();
    public GameObject f;
    public bool damage = false;
    public PolygonCollider2D one;
    public PolygonCollider2D two;

    void Start()
    {
        two.enabled = false;
    }
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
        flames.Add(Instantiate(f, this.transform.position, Quaternion.identity));
        if (flames.Count >= 5)
        {
            Destroy(flames[0].gameObject);
            flames.Remove(flames[0]);
        }
        gameObject.GetComponent<AngerAnimation>().UnFirePong();
    }

    IEnumerator Expand()
    {
        one.enabled = false;
        two.enabled = true;
        damage = true;
        gameObject.GetComponent<AngerAnimation>().FlameExpand();
        yield return new WaitForSeconds(1f);
        damage = false;
        one.enabled = true;
        two.enabled = false;
        gameObject.GetComponent<AngerAnimation>().UnFlameExpand();
    }
}
