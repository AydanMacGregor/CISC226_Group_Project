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

    public bool isScreeching = false;
    private Vector3 todDir;

    private bool wallInWay = false;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 todDir = ((Vector2)Tod.transform.position - (Vector2) thisTransform.position).normalized;
        RaycastHit2D todRayCast = Physics2D.Raycast(thisTransform.position, todDir, 0.5f, LayerMask.GetMask("Confinment", "InnerWall"));
        Debug.DrawLine(this.transform.position, todDir * 2f, Color.white);
        if (todRayCast.collider != null)
        {
            if (todRayCast.collider.name == "OuterWallTileMap" || todRayCast.collider.name == "WallTileMap")
            {
                wallInWay = true;
            }
        }
        else
        {
            wallInWay = false;
        }

        RaycastHit2D hit = Physics2D.Raycast(thisTransform.position, new Vector2(direction.x, direction.y), 1f, LayerMask.GetMask("Confinment", "InnerWall"));
        if (hit.collider != null)
        {
            if (hit.collider.name == "OuterWallTileMap" || hit.collider.name == "WallTileMap")
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
                decisionTimeCount = 1f;
                Move();
            }
        }

        if (!isBiting)
        {
            if (Vector2.Distance(Tod.transform.position, thisTransform.position) <= 5 && !wallInWay)
            {
                Debug.Log("FUCK YOU PUSSY");
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
        if (Vector2.Distance(Tod.transform.position, thisTransform.position) > 2f)
            {
                todDir = (Tod.transform.position - thisTransform.position).normalized;
                rb.velocity = new Vector3(todDir.x * moveSpeed, todDir.y * moveSpeed, 0.0f);
            }
            else
            {
                rb.velocity = Vector2.zero;

                if (attackTime > 0)
                {
                    attackTime -= Time.deltaTime;
                }
                else
                {
                    attackTime = 4f; 
                    int attack = Random.Range(0, 2);
                    this.GetComponent<BAnimation>().chooseAttack(0);
                    this.GetComponent<BAttack>().attackChoice(0);
                }
            }
    }

    void AttackTod()
    {
        if (isMovingBack)
        {
            todDir = (thisTransform.position - Tod.transform.position).normalized;
            transform.position += todDir * moveSpeed * 3 * Time.deltaTime;
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
