using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_tg_I : MonoBehaviour {

    public float MoveSpeed;

    //public float ReachRange;

    public float TimeBetweenMove;

    public float TimeToMove;

    //public float WanderReachNegative;

    private float TimeBetweenMoveCounter;

    private float TimeToMoveCounter;

    private Vector3 MoveDirection;

    private Rigidbody2D MyRigidBody;

    private bool Moving;

    /*private string State;

    private float a;
    private float b;
    private float randomX;
    private float randomY;
    private bool n;*/

	// Use this for initialization
	void Start ()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();

        //State = "RandomState";
        //n = true;

        TimeBetweenMoveCounter = TimeBetweenMove;
        TimeToMoveCounter = TimeToMove;

        //a = MyRigidBody.velocity.x;
        //b = MyRigidBody.velocity.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*if (Mathf.Abs(GetComponent<scr_imput_I>.x - MyRigidBody.velocity.x) < ReachRange && Mathf.Abs( GetComponents<scr_imput_I>.y - MyRigidBody.velocity.y) < ReachRange)
        {
            State = "ChaseState";
        }

        switch (State)
        {
            case "RandomState":
                {
                    if(Random.Range(-1f, 1f) < 0)
                    {
                        State = "WanderState";
                    }
                    else
                    {
                        State = "IdleState";
                    }
                    break;
                };
            case "WandrerState":
                {
                    if(n)
                    {
                        randomX = MyRigidBody.velocity.x + Random.Range(WanderReachNegative, Mathf.Abs(WanderReachNegative));
                        randomY = MyRigidBody.velocity.y + Random.Range(WanderReachNegative, Mathf.Abs(WanderReachNegative));
                        n = false;
                    }
                    else
                    {
                       MyRigidBody.velocity = new Vector3( MyRigidBody.velocity.x + Mathf.Abs(randomX - MyRigidBody.velocity.x) * MoveSpeed * Time.deltaTime , MyRigidBody.velocity.y + Mathf.Abs(randomY - MyRigidBody.velocity.y) * MoveSpeed * Time.deltaTime , 0f);
                    }
                    break;
                };
                
        }*/
		
        if(Moving)
        {
            TimeToMoveCounter -= Time.deltaTime;
            MyRigidBody.velocity = MoveDirection;

            if(TimeToMoveCounter < 0)
            {
                Moving = false;
                TimeBetweenMoveCounter = Random.Range(TimeBetweenMove * 0.75f , TimeBetweenMove * 1.25f);
            }

        } else
        {
            MyRigidBody.velocity = Vector2.zero;
            TimeBetweenMoveCounter -= Time.deltaTime;
            if(TimeBetweenMoveCounter < 0)
            {
                Moving = true;
                TimeToMoveCounter = Random.Range(TimeToMove * 0.75f , TimeToMove * 1.25f);

                MoveDirection = new Vector3(Random.Range(-1f, 1f) * MoveSpeed, Random.Range(-1f, 1f) * MoveSpeed, 0f);
            }
        }
	}
}
