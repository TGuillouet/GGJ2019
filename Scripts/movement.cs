using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	Transform camera;
	public float moveSpeed;
	public float rotationSpeed;
	public float maxVerticalAngle = 280;
	public float minVerticalAngle = 80;
	float verticalRotation;
	// Use this for initialization
	void Start () {
		camera = this.gameObject.transform.GetChild (0);
	}

	// Update is called once per frame
	void Update () {
		verticalRotation = Input.GetAxis ("Vertical2");
		if ((transform.eulerAngles.x >= 0 && transform.eulerAngles.x < minVerticalAngle) || (transform.eulerAngles.x <= 360 && transform.eulerAngles.x > maxVerticalAngle)) {
			transform.Rotate (new Vector3 (-verticalRotation * rotationSpeed, 0, 0), Space.Self);
		}
		else if (transform.eulerAngles.x > minVerticalAngle && transform.eulerAngles.x < (minVerticalAngle + 10) && verticalRotation > 0) {
			transform.Rotate (new Vector3 (-verticalRotation * rotationSpeed, 0, 0), Space.Self);
		}
		else if (transform.eulerAngles.x < maxVerticalAngle && transform.eulerAngles.x > (maxVerticalAngle - 10) && verticalRotation < 0) {
			transform.Rotate (new Vector3 (-verticalRotation * rotationSpeed, 0, 0), Space.Self);
		}
		transform.Translate(new Vector3 (Input.GetAxis ("Horizontal"),0 , Input.GetAxis ("Vertical")) * moveSpeed,Space.Self);
		transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal2") * rotationSpeed,0),Space.World);
		camera.localPosition = new Vector3 (0, 0, 0);
	}
}
