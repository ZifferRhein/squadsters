using UnityEngine;
using System.Collections;

public class scr_imput_I : MonoBehaviour 
{
	public float pl_movespeed;

	private Animator anim;

    private bool player_moving;

    private Vector2 last_move;

    private Rigidbody2D MyRigidbody;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
        MyRigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        //Moving
        player_moving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.4f || -0.4f > Input.GetAxisRaw("Horizontal"))
        {
            last_move = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            MyRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * pl_movespeed, MyRigidbody.velocity.y);
            player_moving = true;
        }

        if (Input.GetAxisRaw("Vertical") > 0.4f || -0.4f > Input.GetAxisRaw("Vertical"))
        {
            last_move = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * pl_movespeed);
            player_moving = true;
        }

        if (Input.GetAxisRaw("Horizontal") < 0.4f &&-0.4f < Input.GetAxisRaw("Horizontal"))
        {
            MyRigidbody.velocity = new Vector2(0f, MyRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.4f && -0.4f < Input.GetAxisRaw("Vertical"))
        {
            MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x, 0f);
        }

            //Animating the movement
            anim.SetBool("PlayerMoving", player_moving);
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("LastMoveX", last_move.x);
        anim.SetFloat("LastMoveY", last_move.y);

    }
}
