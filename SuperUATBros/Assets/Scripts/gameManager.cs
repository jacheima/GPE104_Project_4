﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public int zHealth = 5;
    public float zSpeed = .5f;

    public int pHealth = 100;
    public float Speed = 3f;

    public int coins = 0;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
    

    public GameObject player;
    public bool isPlayerAttacking = false;
    public bool isEnemyInTrigger = false;

    public ZombieController zombieController;

    public Text coinText;

    public Transform[] checkpoints;
    private Transform currentCheckpoint;
    public int currentCheckpointIndex = 0;

    public AudioClip deathSound;
    public AudioSource deatheffect;




    //Static instance of GameManager which allows it to be accessed by any other script.
    public static gameManager instance = null;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // Use this for initialization


    }

    // Use this for initialization
    void Start ()
    {
        currentCheckpoint = checkpoints[currentCheckpointIndex];
        deatheffect.clip = deathSound;

    }
	
	// Update is called once per frame
	void Update () {
	    if (player.transform.position.x >= checkpoints[0].transform.position.x)
	    {
	        currentCheckpointIndex = 1;
	    }
	    if (player.transform.position.x >= checkpoints[1].transform.position.x)
	    {
	        currentCheckpointIndex = 2;
	    }
    }



    public void DecrementEnemyHealth()
    {
        if (isEnemyInTrigger == true && isPlayerAttacking == true)
        {
            zHealth -= 1;
        }
        
        if (zHealth <= 0)
        {
            KillEnemy();
        }
    }
    public void KillEnemy()
    {
        zombieController.KillZombie();
    }
    public void EnemyInTrigger()
    {
        isEnemyInTrigger = true;
        DecrementEnemyHealth();
    }
    public void PlayerAttacking()
    {
        isPlayerAttacking = true;
        DecrementEnemyHealth();
    }
     public void DecrementPlayerHealth()
    {
        pHealth -= 10;

        if (pHealth <= 80)
        {
            heart5.SetActive(false);
        }
        if (pHealth <= 60)
        {
            heart4.SetActive(false);
        }
        if (pHealth <= 40)
        {
            heart3.SetActive(false);
        }
        if (pHealth <= 20)
        {
            heart2.SetActive(false);
        }
        if (pHealth <= 0)
        {
            deatheffect.clip = deathSound;
            heart1.SetActive(false);
            PlayerDeath();
        }
        
    }



    public void PlayerDeath()
    {
        player.GetComponent<Animator>().SetInteger("pHealth", 0);
        TeleportToCheckPoint();

    }
    public void TeleportToCheckPoint()
    {
        Debug.Log("Teleport to checkpoint activated");
        player.GetComponent<Animator>().SetInteger("pHealth", 100);
        pHealth = 100;
        player.transform.position = new Vector3(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y, -.11f);
        heart5.SetActive(true);
        heart4.SetActive(true);
        heart3.SetActive(true);
        heart2.SetActive(true);
        heart1.SetActive(true);
    }

    public void GetCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }


    
}
