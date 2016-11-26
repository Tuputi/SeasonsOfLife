using UnityEngine;
using System.Collections;

public abstract class SeasonObject : MonoBehaviour {

	protected Season SeasonState;


	public void ChangeSeason(Season newSeason){

		this.SeasonState = newSeason;
		_HandleSeasonChange (newSeason);
	}

	protected abstract void _HandleSeasonChange (Season newSeason);
    public abstract bool HandleTriggerEvent(bool enter);
    public abstract void HandleInteraction();




}

