using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDoorAnim : MonoBehaviour
{

    public Animator ani;

	// Use this for initialization
	void Start ()
	{
	    ani.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
