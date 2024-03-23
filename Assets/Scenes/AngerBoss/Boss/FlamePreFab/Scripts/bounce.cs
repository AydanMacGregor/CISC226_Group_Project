using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    internal Transform thisTransform;
    private Rigidbody2D rb;
    public Vector3 direction;
    private SpriteRenderer sr;
    private float timer = 0.25f;
    
    void Start()
    {
        thisTransform = this.transform;
        sr = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
        ChooseMoveDirection();
    }

    void FixedUpdate()
    {
        if (timer < 0)
        {
            timer = 0.25f;
            sr.flipX = sr.flipX ? false : true;
        }
        timer -= Time.deltaTime;
        thisTransform.position += direction * Time.deltaTime * 5f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        direction = Vector3.Reflect(direction, other.contacts[0].normal);
        direction.z = 0f;
    }

    void ChooseMoveDirection()
    {
        direction = new Vector3(Random.Range(-3, 3), Random.Range(-3,3), 0).normalized;
        while (direction.x == 0 && direction.y == 0)
        {
            direction = new Vector3(Random.Range(-3, 3), Random.Range(-3,3), 0).normalized;
        }
    }
    
}
