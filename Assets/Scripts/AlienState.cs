using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AlienState : MonoBehaviour {

    public enum State { SEARCHING, WANDERING, CHASING, ESCAPING }
    public Transform player;
    [SerializeField]
    public State state = State.WANDERING;
    NavMeshAgent agent;
    public Transform currentWaypoint;
    [SerializeField]
    Transform[] waypoints;
    FieldOfView fow;
    public bool playerSeen;
    public float normalSpeed = 4f;
    public float chasingSpeed = 8f;

    private void Start()
    {
        fow = GetComponent<FieldOfView>();
        state = State.WANDERING;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = normalSpeed;
        currentWaypoint = waypoints[20];// waypoints[Random.Range(0, waypoints.Length)];
        agent.SetDestination(currentWaypoint.position);
        playerSeen = false;
    }

    
    private void Update()
    {        
        playerSeen = fow.visibleTargets.Count > 0;
        ExecuteState();
        CheckState();
    }
    [SerializeField]
    private float time = 7f;
    private float timer;
    [SerializeField]
    private float chasingTime = 3f;
    private float chasingTimer;

    void ExecuteState()
    {
        switch (state)
        {
            case State.WANDERING:
                doWander();
                break;
            case State.SEARCHING:
                doSearch();
                break;
            case State.CHASING:
                doChase();
                break;
            case State.ESCAPING:
                doEscape();
                break;
        }
    }



    void doWander()
    {

        if (currentWaypoint == null)
        {
            currentWaypoint = waypoints[Random.Range(0, waypoints.Length)];
            agent.SetDestination(currentWaypoint.position);
            
        }
        agent.Resume();
    }
    void doSearch()
    {
        agent.Stop();
        currentWaypoint = null;
    }
    void doChase()
    {
        
        currentWaypoint = player;        
        agent.SetDestination(currentWaypoint.position);
        agent.Resume();
    }
    void doEscape()
    {

    }


    private void CheckState()
    {
        switch (state)
        {
            case State.WANDERING:
                //if the player is seen, go to chasing
                if (playerSeen)
                {
                   
                    chasingTime = Random.Range(3f, 5f);
                    agent.speed = chasingSpeed;
                    state = State.CHASING;
                }
                //if the target has been reached, then go toSearching.
                else if (currentWaypoint)
                {
                    if ((transform.position - currentWaypoint.position).sqrMagnitude <= agent.stoppingDistance * agent.stoppingDistance)
                    {
                        time = Random.Range(7f, 14f);
                        agent.speed = normalSpeed;
                        state = State.SEARCHING;
                    }
                }               
                //if reaceiving damage, go to escaping
                break;
            case State.SEARCHING:
                //if time's up, then go to wandering
                //if player seen go to chasing
                if (playerSeen)
                {
                    
                    chasingTime = Random.Range(3f, 5f);
                    agent.speed = chasingSpeed;
                    state = State.CHASING;
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer >= time)
                    {
                        timer = 0;
                        agent.speed = normalSpeed;
                        state = State.WANDERING;
                    }
                }         
                
                //if taking damage go to escape
                break;
            case State.CHASING:
                //if player is not seen for some time, go to searching
                if (!playerSeen)
                {
                    chasingTimer += Time.deltaTime;
                    if (chasingTimer >= chasingTime)
                    {
                        chasingTimer = 0;
                        agent.speed = normalSpeed;
                        state = State.SEARCHING;
                    }
                }
                else
                {
                    
                    chasingTime = Random.Range(3f, 5f);
                    chasingTimer = 0;
                }

                break;
            case State.ESCAPING:
               
                break;
        }
    }


    

}
