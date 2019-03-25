using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public float speed = .5f;
    public SpriteRenderer spriteRender;
    public PolygonCollider2D polyCollider;

    public float moveDirection = 1;

    public GameObject zombie;

	// Use this for initialization
	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
        polyCollider = GetComponent<PolygonCollider2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed * moveDirection);
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Ground")
        {
            spriteRender.flipX = !spriteRender.flipX;
            moveDirection *= -1;

        }
    }

    public void KillZombie()
    {
        Destroy(zombie);
        gameManager.instance.zHealth = 5;
    }


}
