using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof (BoxCollider2D))]

public class WaterScript : SeasonObject {

	BoxCollider2D iceCollider;

	void Start(){
		iceCollider = GetComponent<BoxCollider2D> ();

		switch (SeasonState) {
			case Season.Winter:
				iceCollider.enabled = true;
				break;
			default:
				iceCollider.enabled = false;
				break;
		}
	}


	protected override void _HandleSeasonChange(Season newSeason){
		switch (newSeason) {
			case Season.Winter:
				iceCollider.enabled = true;
				break;
			default:
				iceCollider.enabled = false;
				break;
		}
	}

    public override bool HandleTriggerEvent(bool enter)
    {
        throw new NotImplementedException();
    }

    public override void HandleInteraction()
    {
        throw new NotImplementedException();
    }
}
