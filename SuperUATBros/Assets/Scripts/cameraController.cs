using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public Transform player;
    private Vector3 offset;
    
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


        
        transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y - .83f, -1, Mathf.Infinity), player.transform.position.z) + offset;
        

        

    }
}
