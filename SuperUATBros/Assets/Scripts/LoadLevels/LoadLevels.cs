﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
}
