using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour {

    public Animator anim;
    private bool open;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        open = false;
    }
    // Update is called once per frame
    void Update () {
        anim.SetBool("open", open);
	}


    public void Interact()
    {
        Debug.Log("Interact");
        open = !open;
    }
}
