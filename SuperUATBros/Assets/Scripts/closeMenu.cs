﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeMenu : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CloseMenu()
    {
        anim.SetBool("isOpen", false);

    }
}
