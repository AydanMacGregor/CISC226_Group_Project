using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMovement : MonoBehaviour
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

    public bool isBiting = false;
    public bool isMovingBack = false;
    public bool isAttack = false;

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
            if (!isBiting)
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
            else
            {
                AttackTod();
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
        else if (!isAttack)
        {
            todDir = (Tod.transform.position - thisTransform.position).normalized;
            rb.velocity = new Vector3(todDir.x * moveSpeed, todDir.y * moveSpeed, 0.0f);
        }
        if (attackTime < 0)
        {
            attackTime = 4f; 
            int attack = Random.Range(0, 3);
            attackTime = 3f + ((float)attack * 1.5f);
            if (attack == 2)
            {
                this.GetComponent<BAttack>().attackChoice(attack);
            }
            else
            {
                this.GetComponent<BAttack>().attackChoice(attack);
                this.GetComponent<BAnimation>().chooseAttack(attack);
            }
        }
        attackTime -= Time.deltaTime;
    }

    void AttackTod()
    {
        if (isMovingBack)
        {
            float distance = Vector2.Distance(Tod.transform.position, thisTransform.position);
            if (distance < 1.5f)
            {
                todDir = (thisTransform.position - Tod.transform.position).normalized;
                transform.position += todDir * moveSpeed * 3 * Time.deltaTime;
            }
        }
        else
        {
            todDir = (Tod.transform.position - thisTransform.position).normalized;
            transform.position += todDir * moveSpeed * 2 * Time.deltaTime;
        }
    }
    

    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tod")
        {
            this.GetComponent<BAttack>().StopAllCoroutines();
            StartCoroutine(this.GetComponent<BAttack>().MoveAway());
        }
    }
}
