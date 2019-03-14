using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 1f;
    private bool isJumping = false;
    public float jumpHeight = 5f;

    private Rigidbody2D rb;
    public float theScale = 0.25f;

    public Animator anim;


	// Use this for initialization
	void Start ()
	{
	    theScale = transform.localScale.x;
	    rb = GetComponent<Rigidbody2D>();
	    

	}
	
	// Update is called once per frame
    void Update()
    {
     

        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
            isJumping = true;
        }

        float velocityX = Input.GetAxis("Horizontal");
        float velocityY = rb.velocity.y;

        rb.velocity = new Vector2(velocityX * Speed, velocityY);

        anim.SetFloat("Speed", Mathf.Abs(velocityX));

        //transform.right = rb.velocity.normalized;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }




    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isJumping = false;
        }
    }

}
