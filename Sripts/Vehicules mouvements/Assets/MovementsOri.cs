using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsOri : MonoBehaviour {

	public float speedR = 25f;
	private float maxangle = 340f;
	private float minangle = 20f;
	private float limitRU = 335f;
	private float limitLD = 22f;

	// Use this for initialization
	void Start () {
		transform.Rotate (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		bool z = Input.GetKey (KeyCode.Z);
		bool s = Input.GetKey (KeyCode.S);
		bool q = Input.GetKey (KeyCode.Q);
		bool d = Input.GetKey (KeyCode.D);
		bool space = Input.GetKey (KeyCode.Space);

		if (z == true) {
			
			if (q == true && (transform.eulerAngles.z > 358f || transform.eulerAngles.z < minangle)) {
				transform.Rotate (Vector3.forward, speedR * Time.deltaTime);
			} else if (q == false && transform.eulerAngles.z < limitLD) {
				transform.Rotate (Vector3.forward, -speedR * Time.deltaTime);
			}

			if (d == true && (transform.eulerAngles.z > maxangle || transform.eulerAngles.z == 0f || transform.eulerAngles.z < 0.4f)) {
				transform.Rotate (Vector3.forward, -speedR * Time.deltaTime);
			} else if (d == false && transform.eulerAngles.z > limitRU) {
				transform.Rotate (Vector3.forward, speedR * Time.deltaTime);
			}

			if (space == true && (transform.eulerAngles.x > maxangle || transform.eulerAngles.x == 0f || transform.eulerAngles.x < 0.4f)) {
				transform.Rotate (Vector3.left, speedR * Time.deltaTime);
			} else if (space == false && transform.eulerAngles.x > limitRU) {
				transform.Rotate (Vector3.left, -speedR * Time.deltaTime);
			}

			if (s == true && (transform.eulerAngles.x > 358f || transform.eulerAngles.x < minangle)) {
				transform.Rotate (Vector3.left, -speedR * Time.deltaTime);
			} else if (s == false && transform.eulerAngles.x < limitLD) {
				transform.Rotate (Vector3.left, speedR * Time.deltaTime);
			}

		} else {
			if (transform.eulerAngles.x > limitRU) {
				transform.Rotate (Vector3.left, -speedR * Time.deltaTime);
			}
			if (transform.eulerAngles.x < limitLD) {
				transform.Rotate (Vector3.left, speedR * Time.deltaTime);
			}
			if (transform.eulerAngles.z < limitLD) {
				transform.Rotate (Vector3.forward, -speedR * Time.deltaTime);
			}
			if (transform.eulerAngles.z > limitRU) {
				transform.Rotate (Vector3.forward, speedR * Time.deltaTime);
			}
		}
	}
}
