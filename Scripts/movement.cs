using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	Transform camera;
	public float moveSpeed;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		camera = this.gameObject.transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3 (Input.GetAxis ("Horizontal"),0 , Input.GetAxis ("Vertical")) * moveSpeed,Space.Self);
		transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal2") * rotationSpeed,0),Space.World);
		transform.Rotate (new Vector3 (-Input.GetAxis ("Vertical2") * rotationSpeed, 0, 0), Space.Self);
	}
}
