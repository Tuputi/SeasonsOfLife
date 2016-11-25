using UnityEngine;
using System.Collections;

public abstract class SeasonObject : MonoBehaviour {

	Season SeasonState;


	public void ChangeSeason(Season newSeason){

		this.SeasonState = newSeason;
		_HandleSeasonChange (newSeason);
	}

	public abstract void _HandleSeasonChange (Season newSeason);

    

		
}

