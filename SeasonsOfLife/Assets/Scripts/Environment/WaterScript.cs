using UnityEngine;
using System.Collections;

public class WaterScript : SeasonObject {

	BoxCollider2D iceCollider;

	void Start(){
		iceCollider = GetComponent<BoxCollider2D> ();
	}


	public override void _HandleSeasonChange(Season newSeason){
		switch (newSeason) {
		case Season.Winter:
			break;
		default:
			
			break;
		}
	}
}
