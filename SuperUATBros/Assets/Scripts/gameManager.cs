using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
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
            Destroy(heart5);
        }
        if (pHealth <= 60)
        {
            Destroy(heart4);
        }
        if (pHealth <= 40)
        {
            Destroy(heart3);
        }
        if (pHealth <= 20)
        {
            Destroy(heart2);
        }
        if (pHealth <= 0)
        {
            Destroy(heart1);
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
        player.GetComponent<Animator>().SetInteger("pHealth", 100);
        pHealth = 100;
        player.transform.position = new Vector3(-40.35f, -1.395f, -0.11f);
    }
    
}
