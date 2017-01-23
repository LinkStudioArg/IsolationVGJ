using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AlienMovement : MonoBehaviour {

    AlienState alienState;
    NavMeshAgent agent;



    // Use this for initialization
    void Start () {
        alienState = GetComponent<AlienState>();
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (alienState.state)
        {
            case AlienState.State.WANDERING:
                agent.SetDestination(alienState.currentWaypoint.position);
                break;
            case AlienState.State.SEARCHING:

                break;
        }
	}
}
