using System;
using UnityEngine;


public abstract class GenericAnimal : SeasonObject
{
	public bool dead;

	public Animator animator;
	public GameObject soulPrefab;

	public int Soulpower {
		get;

		protected set;
	}

	void FixedUpdate(){

		AI ();

	}

	public void Kill(){
		dead = true;
		//animator.SetTrigger ("die");

		GameObject soul = GameObject.Instantiate (soulPrefab);

		soul.GetComponent<SoulScript>().SetTargets(transform.position, FindObjectOfType<CharacterControler>().gameObject, 
			() => {
				FindObjectOfType<CharacterControler>().soulPoints+=Soulpower;
			}); 
	}

	public void Revive(){
		//animator.SetTrigger ("revive");


		GameObject soul = GameObject.Instantiate (soulPrefab);


		soul.GetComponent<SoulScript>().SetTargets(FindObjectOfType<CharacterControler>().transform.position, gameObject, 
			() => {
				dead = false;
			}); 
	}

	protected abstract void AI ();

	public override void HandleInteraction()
	{
		CharacterControler player = FindObjectOfType<CharacterControler> ();
		Debug.Log ("player points: " + player.soulPoints);
		if (!dead) {
			this.Kill ();
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


