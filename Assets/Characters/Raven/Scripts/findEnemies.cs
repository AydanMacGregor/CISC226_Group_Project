using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findEnemies : MonoBehaviour
{
    private Vector3 enemyPos;
    public GameObject todPos;
    private bool hit;
    private GameObject en;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D hitColliders = Physics2D.OverlapCircle(transform.transform.localPosition, 5f, LayerMask.GetMask("Bat", "Soul"));
        en = hitColliders.gameObject;
        todPos = GameObject.FindWithTag("Tod");
    }

    void Update()
    {
        if (en != null && !hit)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, en.transform.position, 3f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, todPos.transform.position, 3f * Time.deltaTime);
            if (Vector2.Distance(this.transform.position, todPos.transform.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.layer);
        if (col != null)
        {
            if (col.gameObject.layer == 12 || col.gameObject.layer == 9)
            {
                hit = true;
            }
        }
    }
}
