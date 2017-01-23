using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    [SerializeField]
    private float reachDistance=10f;

    [SerializeField]
    private ObjectInteract objectInteract;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, reachDistance))
        {
            objectInteract = hit.collider.gameObject.GetComponent<ObjectInteract>();
            if (objectInteract)
            {
                if(Input.GetKeyDown(KeyCode.E))
                    objectInteract.Interact();
            }     
        }	
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * reachDistance);
    }
}
