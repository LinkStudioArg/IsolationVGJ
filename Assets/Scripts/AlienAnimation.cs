using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AlienAnimation : MonoBehaviour {

    private Animator anim;
    NavMeshAgent agent;

    public bool crouch;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    float animSpeed;
    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude);
        crouch = anim.GetBool("crouch") || anim.velocity.magnitude > 7;
       
    }

    private void OnTriggerEnter()
    {
        Debug.Log("Test");
        anim.SetBool("crouch", !anim.GetBool("crouch"));
    }
}
