using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsPos : MonoBehaviour {

	public float speedT = 5f;
	public float speedR = 25f;
	public float speedFall = 0.1f;
	public float minThreshold = -50f;
	public float maxThreshold = 100f;
	public float pourcentageSpeed = 0.5f;

	void Start () {
		transform.Translate (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		bool z = Input.GetKey (KeyCode.Z);
		bool s = Input.GetKey (KeyCode.S);
		bool q = Input.GetKey (KeyCode.Q);
		bool d = Input.GetKey (KeyCode.D);
		bool space = Input.GetKey (KeyCode.Space);

		if (z == true) {
			transform.Translate (Vector3.forward * speedT * Time.deltaTime);

			if (q == true) {
				transform.Rotate (Vector3.up, -speedR * Time.deltaTime);
			}
			if (d == true) {
				transform.Rotate (Vector3.up, speedR * Time.deltaTime);
			}
			if (space == true) {
				transform.Translate (Vector3.up * speedT * pourcentageSpeed * Time.deltaTime);
			}
			if (s == true) {
				transform.Translate (Vector3.up * -speedT * pourcentageSpeed * Time.deltaTime);
			}
		}


		if (transform.position.y < minThreshold) {
			Debug.Log (transform.position.y);
			transform.position = new Vector3 (transform.position.x, minThreshold, transform.position.z);
		}

		if (transform.position.y > maxThreshold) {
			transform.position = new Vector3 (transform.position.x, maxThreshold, transform.position.z);
		}

		if (transform.position.y >= minThreshold) {
			transform.Translate (Vector3.up * -speedFall * Time.deltaTime);
		}
	}
}
