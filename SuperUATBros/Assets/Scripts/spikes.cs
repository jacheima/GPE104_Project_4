using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour {

    public AudioClip SpikeSound;

    public AudioSource SpikeEffect;

	// Use this for initialization
	void Start () {
        SpikeEffect.clip = SpikeSound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SpikeEffect.Play();
            gameManager.instance.DecrementPlayerHealth();

        }
    }
}
