using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundNPC : Sign
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    private bool isMoving;
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeSec;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeSec;
    
    // Start is called before the first frame update
    void Start()
    {
        moveTimeSec = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSec = Random.Range(minWaitTime, maxWaitTime);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isMoving)
        {
            moveTimeSec -= Time.deltaTime;
            if (moveTimeSec <= 0)
            {
                moveTimeSec = Random.Range(minMoveTime, maxMoveTime);
                isMoving = false;
            }
            if (!playerInRange)
            {
                Move();
            }
        }
        else
        {
            waitTimeSec -= Time.deltaTime;
            if (waitTimeSec <= 0)
            {
                ChooseDiffDirection();
                isMoving = true;
                waitTimeSec = Random.Range(minWaitTime, maxWaitTime);
            }
        }
    }

    private void ChooseDiffDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            Debug.Log("here");
            loops++;
            ChangeDirection();
        }
    }
    void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                //walk right
                directionVector = Vector3.right;
                break;
            case 1:
                //walk up
                directionVector = Vector3.up;
                break;
            case 2:
                //walk left
                directionVector = Vector3.left;
                break;
            case 3:
                //walk down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("moveX", directionVector.x);
        anim.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ChooseDiffDirection();
    }
}
