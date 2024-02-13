using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 move;
    int movementSpeed = 4;
    public Vector2 direction;
    public GameObject tod;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX > 0)
        {
            direction = Vector2.right;
        }
        else if (moveX < 0)
        {
            direction = Vector2.left;
        }
        else if (moveY > 0)
        {
            direction = Vector2.up;
        }
        else if (moveY < 0)
        {
            direction = Vector2.down;
        }
        move = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector3(move.x * movementSpeed, move.y * movementSpeed, 0.0f);
    }
}
