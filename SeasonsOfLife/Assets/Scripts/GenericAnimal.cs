using System;
using UnityEngine;


public abstract class GenericAnimal : SeasonObject
{
	public bool dead;

	public Animator animator;

	public int Soulpower {
		get;

		protected set;
	}

	void FixedUpdate(){

		AI ();

	}

	public int Kill(){
		dead = true;
		//animator.SetTrigger ("die");
		return Soulpower;
	}

	public void Revive(){
		//animator.SetTrigger ("revive");

		dead = false;
	}

	protected abstract void AI ();

	public override void HandleInteraction()
	{
		CharacterControler player = FindObjectOfType<CharacterControler> ();
		Debug.Log ("player points: " + player.soulPoints);
		if (!dead) {
			player.soulPoints += this.Kill ();
		} else{
			if (player.soulPoints >= this.Soulpower) {
				player.soulPoints -= this.Soulpower;
				this.Revive ();
			}
		}
	}

	public override bool HandleTriggerEvent(bool enter)
	{
		if (enter)
		{
			InteractionScript.InteractionPossible(this);
		}
		else
		{
			InteractionScript.InteractionCancelled();
		}

		return true;
	}


}


