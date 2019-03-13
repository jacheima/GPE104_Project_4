using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 1f;
    private bool isJumping = false;
    public float maxJumpTimes = 2;
    public float jumpHeight = 12f;

    private Rigidbody2D rb;
    public float someScale = 3;

    public Animator anim;


	// Use this for initialization
	void Start ()
	{
	    someScale = transform.localScale.x;
	    rb = GetComponent<Rigidbody2D>();
	    

	}
	
	// Update is called once per frame
    void Update()
    {
     

        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
        }

            float velocityX = Input.GetAxis("Horizontal");
            float velocityY = rb.velocity.y;

            rb.velocity = new Vector2(velocityX * Speed, velocityY);

        anim.SetFloat("Speed", Mathf.Abs(velocityX));
  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isJumping = false;
        }
    }

}
