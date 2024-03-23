using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementD : MonoBehaviour
{
    internal Transform thisTransform;
    public GameObject Tod;
    private float attackTime = 2f;
    private float moveSpeed = 2f;
    private Vector2 decisionTime = new Vector2(1, 6);
    public Vector3 direction;
    internal float decisionTimeCount = 0;
    internal Vector3[] moveDirections = new Vector3[] {Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.zero };
    internal int currentMoveDirection;

    // New edit
    public bool chargeFlag = false;
    public bool isMovingBack = false;
    private Vector3 todDir;

    private int attackChoice;

    void Start()
    {
        thisTransform = this.transform;
        // Set a random time delay for taking a decision ( changing direction,or standing in place for a while )
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
    }

    void Update()
    {
        if (chargeFlag)
        {
            AttackTod();
        }
        else if (!GameObject.FindWithTag("CheckPoint"))
        {
            if (Vector2.Distance(Tod.transform.position, thisTransform.position) <= 8)
            {
                FollowTod();
            }
            else
            {
                Move();
            }
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(thisTransform.position, new Vector2(direction.x, direction.y), 2.5f, LayerMask.GetMask("Confinment"));
        if (hit.collider != null)
        {
            if (hit.collider.name == "OuterWall")
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
        
    }

    public void Move()
    {
        // Move the object in the chosen direction at the set speed
        direction = moveDirections[currentMoveDirection];
        float xDir = direction.x;
        float yDir = direction.y;

        thisTransform.position += direction * Time.deltaTime * moveSpeed;

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
        if (Vector2.Distance(Tod.transform.position, thisTransform.position) > 4f)
        {
            Vector3 oldpos = thisTransform.position;
            Vector3 newpos = Vector2.MoveTowards(thisTransform.position, Tod.transform.position, moveSpeed * Time.deltaTime);
            transform.position = newpos  + new Vector3(0f, 0f, -3f);
            direction = (newpos - oldpos).normalized;
        }
        if (attackTime > 0)
        {
            attackTime -= Time.deltaTime;
        }
        else
        {
            attackChoice = Random.Range(0, 3);
            if (attackChoice == 0)
            {
                attackTime = 6f;
                this.GetComponent<animationD>().chooseAn(attackChoice);
            }
            else if (attackChoice == 1)
            {
                attackTime = 4f;
                this.GetComponent<animationD>().chooseAn(attackChoice);
            }
            else
            {
                attackTime = 3f;
            }
            this.GetComponent<attacking>().StartAttack(attackChoice);
        }
    }

    // Copy from Soul Movement
    public void AttackTod()
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
        if (collision.gameObject.name == "Tod" && chargeFlag)
        {
            //this.GetComponent<attackTod>().StopAllCoroutines();
            //StartCoroutine(this.GetComponent<attackTod>().MoveAwayTod());
        }
    }
}
