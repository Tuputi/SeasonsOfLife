using UnityEngine;
using System.Collections;
using System;

public class BearScirbt : GenericAnimal {

	Vector3 walkDir = new Vector3(-1,0,0);
	float walkSpeed = 1f;

	public float rightBound = 20;

	float targetHeight = 0;


	// Use this for initialization
	void Start () {
		Soulpower = 4;

		targetHeight = transform.position.y;

	}


	protected override void AI ()
	{
		if (dead) {
			return;
		} else {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		}

		if (transform.position.x < rightBound) {
			
			//transform.position = transform.position + walkDir * Time.fixedDeltaTime * walkSpeed;

			GetComponent<Rigidbody2D> ().velocity = walkDir * walkSpeed;

			if (animator != null)
				animator.SetBool ("walking", true);
		} else {
			animator.SetBool ("walking", false);
		}

	}

	protected override void _HandleSeasonChange (Season newSeason){
		
	}

}
