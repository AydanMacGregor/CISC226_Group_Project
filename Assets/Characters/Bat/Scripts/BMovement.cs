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
    private float moveSpeed = 3f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    private Vector2 decisionTime = new Vector2(1, 6);
    public Vector3 direction;
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place.
    internal Vector3[] moveDirections = new Vector3[] {Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.zero };
    internal int currentMoveDirection;

    public Rigidbody2D rb;

    public bool isBiting = false;
    private Vector3 todDir;
    public bool touchingTod = false;
    // Start is called before the first frame update
    void Start()
    {
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
        if (Vector2.Distance(Tod.transform.position, thisTransform.position) <= 5)
            {
                FollowTod();
            }
        else
            {
                Move();
            }
    }

    void Move()
    {
        // Move the object in the chosen direction at the set speed
            direction = moveDirections[currentMoveDirection];
            float xDir = direction.x;
            float yDir = direction.y;

            thisTransform.position += direction * Time.deltaTime * moveSpeed;

            // if (animator)
            // {
            //     animator.SetFloat("MoveX", xDir);
            //     animator.SetFloat("MoveY", yDir);
            // }

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
                transform.position = Vector2.MoveTowards(thisTransform.position, Tod.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                if (attackTime > 0)
                {
                    attackTime -= Time.deltaTime;
                }
                else
                {
                    attackTime = 2f; 
                    this.GetComponent<BAttack>().attackChoice(0);
                }
            }
    }

    void AttackTod()
    {
        if (thisTransform.position != Tod.transform.position)
        {
            todDir = (Tod.transform.position - thisTransform.position).normalized;
            transform.position += todDir * moveSpeed * 2 * Time.deltaTime;
        }
        else
        {
            touchingTod = true;
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
        
    }
}
