using UnityEngine;
using System.Collections;
using System;

public class SoulScript : MonoBehaviour {

	Vector3 targetUpPos;
	GameObject targetObject;

	int state = 0;

	float float_height = 3;
	float float_speed = 1.0f/50;

	Action finishedTask;


	// Use this for initialization
	void Start () {
		//SetTargets (transform.position, FindObjectOfType<CharacterControler> ().gameObject, null);
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		if (state == 0) {
			transform.position = Vector3.Lerp (transform.position, targetUpPos, float_speed);

			if (Vector3.Distance (transform.position, targetUpPos) < 0.6) {
				state = 1;
			}
		} else {
			transform.position = Vector3.Lerp (transform.position, targetObject.transform.position, float_speed);

			if (Vector3.Distance (transform.position, targetObject.transform.position) < 1) {
				if (finishedTask != null) {
					Debug.Log ("wtf");
					finishedTask.Invoke ();
				}

				Destroy (gameObject);
			}
		}
	}

	public void SetTargets(Vector3 origin, GameObject targetObject, Action finished){
		transform.position = origin;
		targetUpPos = origin + (Vector3.up * float_height);
		this.targetObject = targetObject;
		this.finishedTask = finished;
	}
}
