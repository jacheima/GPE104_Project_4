using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{

    public GameObject door;

    public float doorSpeed = 1f;
	// Use this for initialization
	void Start ()
	{
	    

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && gameManager.instance.hasKey == true)
        {
            door.transform.Translate(Vector3.up * Time.deltaTime * doorSpeed);
        }
    }
}
