using System;
using UnityEngine;


public abstract class GenericAnimal : MonoBehaviour
{
	private bool dead;

	public Animator animator;

	public int Soulpower {
		get;

		protected set;
	}

	void FixedUpdate(){

		if (!dead) {
			AI ();
		}
	}

	public int Kill(){
		dead = true;
		animator.SetTrigger ("die");
		return Soulpower;
	}

	public void Revive(){
		animator.SetTrigger ("revive");

		dead = false;
	}

	protected abstract void AI ();
}


