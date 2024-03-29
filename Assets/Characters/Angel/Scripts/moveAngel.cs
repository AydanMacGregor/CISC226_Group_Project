using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAngel : MonoBehaviour
{
    internal Transform thisTransform;
    //public Animator animator;
    public GameObject Tod;
    private float attackTime = 2f;

    // The movement speed of the object
    private float moveSpeed = 2.75f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    private Vector2 decisionTime = new Vector2(1, 6);
    public Vector3 direction;
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place.
    internal Vector3[] moveDirections = new Vector3[] {Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.zero };
    internal int currentMoveDirection;

    public Rigidbody2D rb;

    public bool isDevine = false;
    public bool isMovingBack = false;
    public bool isAttacking = false;

    public bool isScreeching = false;
    private Vector3 todDir;
    private Vector2 prevDir;
    private Vector2 batDir;
    private RaycastHit2D wallCast;
    private Vector2 currDir;
    private RaycastHit2D todCast;

    // Start is called before the first frame update
    void Start()
    {
        Tod = GameObject.FindWithTag("Tod");
        // Cache the transform for quicker access
        thisTransform = this.transform;
        // Set a random time delay for taking a decision ( changing direction,or standing in place for a while )
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
    }

    void FixedUpdate()
    {
        currDir = ((Vector2) thisTransform.position - prevDir).normalized * 0.5f;
        prevDir = (Vector2) thisTransform.position;
        wallCast = Physics2D.Raycast(thisTransform.position, currDir, 1f, LayerMask.GetMask("Confinment", "InnerWall"));
        
        if (wallCast.collider != null && (wallCast.collider.name == "OuterWallTileMap" || wallCast.collider.name == "WallTileMap"))
        {
            if (direction.x < 0)
            {
                currentMoveDirection = 0;
            }
            else if (direction.x > 0)
            {
                currentMoveDirection = 1;
            }
            else if (direction.y < 0)
            {
                currentMoveDirection = 2;
            }
            else if (direction.y > 0)
            {
                currentMoveDirection = 3;
            }
            else
            {
                currentMoveDirection = Random.Range(0,4);
            }
            decisionTimeCount = 1f;
            Move();
        }
        else
        {
            if (!isDevine)
            {
                batDir = ((Vector2) Tod.transform.position - (Vector2) thisTransform.position).normalized;
                todCast = Physics2D.Raycast(thisTransform.position, batDir, 8f, LayerMask.GetMask("Confinment", "InnerWall", "Tod"));
                if (todCast.collider != null && todCast.collider.name == "Tod")
                {
                    FollowTod();
                }
                else
                {
                    Move();
                }
            }
            if (isDevine)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    void Move()
    {
        // Move the object in the chosen direction at the set speed
            direction = moveDirections[currentMoveDirection];
            float xDir = direction.x;
            float yDir = direction.y;

            // thisTransform.position += direction * Time.deltaTime * moveSpeed;
            rb.velocity = new Vector3(xDir * moveSpeed, yDir * moveSpeed, 0.0f);

            if (decisionTimeCount > 0)
            {
                decisionTimeCount -= Time.deltaTime;
            } 
            else
            {
                // Choose a random time delay for taking a decision
                // (changing direction, or standing in place for a while )
                decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

                // Choose a movement direction, or stay in place
                ChooseMoveDirection();
            }
    }

    void FollowTod()
    {
        float distance = Vector2.Distance(Tod.transform.position, thisTransform.position);
        if (distance < 2f)
        {
            rb.velocity = Vector2.zero;
        }
        if (!isAttacking)
        {
            this.transform.position = Vector2.MoveTowards(thisTransform.position, Tod.transform.position, moveSpeed * Time.deltaTime);
        }
        if (attackTime < 0)
        {
            isAttacking = true;
            int attack = Random.Range(0, 2);
            if (attack == 0)
            {
                attackTime = 3f; 
            }
            else
            {
                attackTime = 2f; 
            }
            this.GetComponent<AAttack>().attackChoice(attack);
            this.GetComponent<AAnimation>().chooseAttack(attack);
        }
        attackTime -= Time.deltaTime;
    }
    
    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }
}
