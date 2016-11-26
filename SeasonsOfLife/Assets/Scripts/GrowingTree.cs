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
        HandleTriggerEvent(false);
        if (Grown)
        {
            for (int i = 3; i >= 0; i--)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            transform.FindChild(newSeason.ToString()).gameObject.SetActive(true);
            transform.SetAsFirstSibling();
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
        if (!Grown || SeasonChanger.instance.CurrentSeason!=Season.Autumn)
        {
            //no interaction
            InteractionScript.InteractionCancelled();
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
