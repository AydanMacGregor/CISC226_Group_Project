using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bsoundwave : MonoBehaviour
{
    private Vector3 dir;
    private GameObject tod; 
    public Rigidbody2D rb;
    private float Speed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        tod = GameObject.Find("Tod");
        dir = (tod.transform.position - this.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dir.x * Speed, dir.y * Speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
