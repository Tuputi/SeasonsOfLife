using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof(Rigidbody2D))]

public class BirdScript : GenericAnimal {

	bool flying = true;

	float wobblyness = 8;
	float wobblyAngle = 10;

	Vector3 flyDir = new Vector3(1,0,0);
	float flySpeed = 1f;
	float flyForce = 1f;

	public float leftBound = -10;
	public float rightBound = 10;

	float targetHeight = 0;

	Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
		Soulpower = 1;

		targetHeight = transform.position.y;

		rBody = GetComponent<Rigidbody2D> ();
	}


	protected override void AI ()
	{
		if (dead) {
			return;
		}

		if (flying) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, (Mathf.Sin (Time.time * wobblyness) * wobblyAngle)));
			transform.position = transform.position + (flyDir * flySpeed) * Time.fixedDeltaTime;

			if (transform.position.y < targetHeight) {
				rBody.velocity = Vector3.up * flyForce;			
			}
		} else {
			
		}

		if (transform.position.x > rightBound) {
			flyDir = new Vector3(-1,0,0);
		} else if (transform.position.x < leftBound) {
			flyDir = new Vector3(1,0,0);
		}
	}

	protected override void _HandleSeasonChange (Season newSeason){

		for(int i = 3; i >= 0; i--)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
		transform.FindChild(newSeason.ToString()).gameObject.SetActive(true);

		switch (newSeason) {
			case Season.Winter:
				flying = false;
				break;
			default:
				flying = true;
				break;
		}
	}

}
