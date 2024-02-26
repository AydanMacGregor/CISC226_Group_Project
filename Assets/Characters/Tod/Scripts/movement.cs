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
    public bool doneDialogue;

    public int xFlip = 1;
    public int yFlip = 1;
    private float moveX;
    private float moveY;

    void Awake()
    {
        doneDialogue = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<NovelIdea>().blockInput && doneDialogue)
        {
            ProcessInputs();
        }
        else
        {
            move = Vector2.zero;
        }
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveX *= xFlip;
        moveY *= yFlip;
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
