using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour {

    public AudioClip CoinSound;

    public AudioSource CoinBeep;

	// Use this for initialization
	void Start () {
        CoinBeep.clip = CoinSound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            CoinBeep.Play();
            Destroy(gameObject);
            gameManager.instance.GetCoin();
        }
    }
}
