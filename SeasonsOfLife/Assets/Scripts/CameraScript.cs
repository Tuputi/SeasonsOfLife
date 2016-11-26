using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	CharacterControler player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<CharacterControler> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
	}
}
