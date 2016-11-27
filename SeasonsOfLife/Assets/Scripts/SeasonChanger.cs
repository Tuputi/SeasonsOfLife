using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SeasonChanger : MonoBehaviour {

    public GameObject[] mySeasonsGraphics;
    public Season CurrentSeason;

    public List<SeasonObject> mySeasonObjects;
    public GameObject GameObjectHolder;
    public static SeasonChanger instance;

    int seasonINt = 0;


    void Awake()
    {
        InitiateSeasonObjects();
        instance = this;
        seasonINt = (int)CurrentSeason+1;
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
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ChangeSeason(Season toSeason)
    {
        foreach(SeasonObject so in mySeasonObjects)
        {
            so.ChangeSeason(toSeason);
        }
        CurrentSeason = toSeason;
    }
}
