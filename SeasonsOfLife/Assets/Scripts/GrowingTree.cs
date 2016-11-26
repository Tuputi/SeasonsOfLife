using UnityEngine;
using System.Collections;
using System;

public class GrowingTree : SeasonObject {

    public bool Grown = true;
    public Sprite[] growthStages;
    private Sprite mySprite;
    private int GrowthStateInt = 0;

    void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    protected override void _HandleSeasonChange(Season newSeason)
    {
        if (Grown)
        {
            return;
        }
        if(GrowthStateInt >= 2)
        {
            Grown = true;
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

    public override bool HandleTriggerEvent(bool enter)
    {
        if (!Grown)
        {
            //no interaction
            return false;
        }

        //enter or exit trigger area?
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

    public override void HandleInteraction()
    {
        Debug.Log("Falling");
        GetComponent<Animator>().SetBool("Falling", true);
    }
}
