using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportVertices : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        
        Debug.LogWarning(gameObject.name + " vertices: " + mesh.vertexCount/3);
    }
	
}
