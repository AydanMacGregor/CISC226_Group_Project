using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findEnemies : MonoBehaviour
{
    private Vector3 enemyPos;
    public GameObject todPos;
    private bool hit;
    private GameObject en;
    public SpriteRenderer r;
    private float timer = 2f;
    Collider2D[] results;
    GameObject tod;
    // Start is called before the first frame update
    void Start()
    {
        tod = GameObject.FindWithTag("Tod");
        results = Physics2D.OverlapCircleAll(transform.transform.localPosition, 5f, LayerMask.GetMask("Bat", "Soul"));
        if (results.Length > 0)
        {
            for (int i = 0; i < results.Length; i++)
            {
                Vector2 currDir = (Vector2)(this.transform.position - results[i].gameObject.transform.position);
                RaycastHit2D wallCast = Physics2D.Raycast(this.transform.position, currDir, 5f, LayerMask.GetMask("Confinment", "InnerWall"));
                if (wallCast == false)
                {
                    en = results[i].gameObject;
                    break;
                }
            }
        }
        todPos = GameObject.FindWithTag("Tod");
    }

    void Update()
    {
        if (timer < 0)
        {
            hit = true;
        }
        if (en != null && !hit)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, en.transform.position, 3f * Time.deltaTime);
            if (en.transform.position.x > this.transform.position.x)
            {
                r.flipX = true;
            }
            else
            {
                r.flipX = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, todPos.transform.position, 3f * Time.deltaTime);
            if (todPos.transform.position.x > this.transform.position.x)
            {
                r.flipX = true;
            }
            else
            {
                r.flipX = false;
            }
            if (Vector2.Distance(this.transform.position, todPos.transform.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
        timer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null)
        {
            if (col.gameObject.layer == 12 || col.gameObject.layer == 9)
            {
                hit = true;
            }
        }
    }

    void OnDestroy()
    {
        tod.GetComponent<AttackDefend>().ravens.Remove(this.gameObject);
    }
}
