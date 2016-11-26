using UnityEngine;
using System.Collections;
using System;

public class BearScript : GenericAnimal {

	bool flying = true;


	Vector3 walkDir = new Vector3(1,0,0);
	float walkSpeed = 1f;

	public float rightBound = 20;

	float targetHeight = 0;


	// Use this for initialization
	void Start () {
		Soulpower = 1;

		targetHeight = transform.position.y;

	}


	protected override void AI ()
	{
		if (dead) {
			return;
		}

		if (transform.position.x < rightBound) {
			transform.position += Vector3.right / Time.fixedDeltaTime * walkSpeed;
			if (animator != null)
				animator.SetBool ("walking", true);
		} else {
			animator.SetBool ("walking", false);
		}

	}

	protected override void _HandleSeasonChange (Season newSeason){
		
	}

}
