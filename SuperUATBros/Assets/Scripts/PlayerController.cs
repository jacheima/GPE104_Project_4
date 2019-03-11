using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;
    private bool isJumping = false;
    public float maxJumpTimes = 2;
    public float jumpHeight = 12f;

    private Rigidbody2D rb;
    public float someScale = 3;


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

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
            transform.position += -Vector3.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
            transform.position += Vector3.right * Time.deltaTime * speed;
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
