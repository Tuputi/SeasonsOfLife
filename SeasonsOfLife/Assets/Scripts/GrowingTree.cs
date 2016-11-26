using UnityEngine;
using System.Collections;

public class GrowingTree : SeasonObject {

    public Sprite[] growthStages;
    private Sprite mySprite;
    private int GrowthStateInt = 0;

    void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    protected override void _HandleSeasonChange(Season newSeason)
    {
        if(GrowthStateInt >= 2)
        {
            Debug.Log("Done growing!");
            return;
        }
        GrowthStateInt++;
        ChangeSprite();
    }

    void ChangeSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = growthStages[GrowthStateInt];
    }
}
