using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainClap : MonoBehaviour
{
    private Vector3 dir;
    private GameObject tod;
    public Rigidbody2D rb;
    private float Speed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tod = GameObject.FindWithTag("Tod");

        dir = (tod.transform.position - transform.position);
        rb.velocity = new Vector2(dir.x, dir.y).normalized * Speed;

        float rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 90);

        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Boss")
        {
            Destroy(gameObject);
        }

    }
}
