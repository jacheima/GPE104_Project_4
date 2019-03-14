using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float speed = 1f;
    private Transform currentPatrolPoint;
    private int currentPatrolIndex;

	// Use this for initialization
	void Start ()
	{
	    currentPatrolIndex = 0;
	    currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}
	
	// Update is called once per frame
	void Update () {
		


    }
}
