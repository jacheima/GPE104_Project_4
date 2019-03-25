using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 3f;
    private bool isJumping = false;
    public float jumpHeight = 6f;

    private Rigidbody2D rb;
    public float theScale = 0.25f;

    public Animator anim;

    private bool isAttacking = false;


    public Collider2D attackTrigger;

    

    
    


	// Use this for initialization
	void Start ()
	{
	    theScale = transform.localScale.x;
	    rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackTrigger.enabled = false;

        
	    

	}
	
	// Update is called once per frame
    void Update()
    {
     
        if (Input.GetKey(KeyCode.F) && isAttacking == false)
        {
            anim.SetBool("isAttacking", true);
            attackTrigger.enabled = true;

            gameManager.instance.PlayerAttacking();

        }
        else
        {
            anim.SetBool("isAttacking", false);
            attackTrigger.enabled = false;
        }
        
        
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
