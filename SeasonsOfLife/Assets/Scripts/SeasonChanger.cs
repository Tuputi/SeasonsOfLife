using UnityEngine;
using System.Collections.Generic;

public class SeasonChanger : MonoBehaviour {

    public GameObject[] mySeasonsGraphics;
    public Season CurrentSeason;

    public List<SeasonObject> mySeasonObjects;
    public GameObject GameObjectHolder;


    public void InitiateSeasonObjects()
    {
        for(int i = GameObjectHolder.transform.childCount; i > 0; i--)
        {
            mySeasonObjects.Add(GameObjectHolder.transform.GetChild(i).GetComponent<SeasonObject>());
        }
    }

    public void ChangeSeason(Season toSeason)
    {
        foreach(SeasonObject so in mySeasonObjects)
        {
            so.ChangeSeason(toSeason);
        }
    }
}
