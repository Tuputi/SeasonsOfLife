using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider2D))]

public class WaterScript : SeasonObject {

	BoxCollider2D iceCollider;

	void Start(){
		iceCollider = GetComponent<BoxCollider2D> ();
	}


	public override void _HandleSeasonChange(Season newSeason){
		switch (newSeason) {
			case Season.Winter:
				iceCollider.enabled = true;
				break;
			default:
				iceCollider.enabled = false;
				break;
		}
	}
}
