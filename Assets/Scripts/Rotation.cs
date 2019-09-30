using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    [SerializeField] float rotationSpeed;

	// Use this for initialization
	void Awake () {
        rotationSpeed *= Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationSpeed, 0f, 0f); 
	}
}
