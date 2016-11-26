using UnityEngine;
using System.Collections.Generic;

public class SeasonChanger : MonoBehaviour {

    public GameObject[] mySeasonsGraphics;
    public Season CurrentSeason;

    public List<SeasonObject> mySeasonObjects;
    public GameObject GameObjectHolder;

    int seasonINt = 0;


    void Awake()
    {
        InitiateSeasonObjects();
    }



    public void InitiateSeasonObjects()
    {
        mySeasonObjects = new List<SeasonObject>();
        for(int i = GameObjectHolder.transform.childCount-1; i >= 0; i--)
        {
            mySeasonObjects.Add(GameObjectHolder.transform.GetChild(i).GetComponent<SeasonObject>());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSeason((Season)seasonINt);
            seasonINt++;
            if(seasonINt > 3)
            {
                seasonINt = 0;
            }
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
