using UnityEngine;
using System.Collections;


public class BirdScript : GenericAnimal {

	bool flying = true;

	float wobblyness = 8;
	float wobblyAngle = 10;

	Vector3 flyDir = new Vector3(1,0,0);
	float flySpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}


	protected override void AI ()
	{
		if(flying){
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, (Mathf.Sin(Time.time*wobblyness)*wobblyAngle) ));
			transform.position = transform.position + (flyDir * flySpeed)*Time.fixedDeltaTime;
		}

		if (transform.position.x > 3) {
			flyDir = new Vector3(-1,0,0);
		} else if (transform.position.x < -4) {
			flyDir = new Vector3(1,0,0);
		}
	}
}
