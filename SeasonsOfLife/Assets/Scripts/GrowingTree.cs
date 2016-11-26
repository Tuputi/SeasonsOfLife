using UnityEngine;
using System.Collections;
using System;

public class GrowingTree : SeasonObject {

    public bool Grown = true;
    public bool Fallen = false;
    public Sprite[] growthStages;
    private Sprite mySprite;
    private int GrowthStateInt = 0;

    public BoxCollider2D bridgeCollider;
    public BoxCollider2D blockCollider;

    void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>().sprite;
        bridgeCollider = this.GetComponent<BoxCollider2D>();
        blockCollider = this.transform.FindChild("BlockCollider").GetComponent<BoxCollider2D>();
    }


    protected override void _HandleSeasonChange(Season newSeason)
    {
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
        if (!Grown || SeasonChanger.instance.CurrentSeason!=Season.Autumn || Fallen)
        {
            //no interaction
            return false;
        }

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
        Fallen = true;
    }

    public void activateCollider() {
        bridgeCollider.isTrigger = false;
        blockCollider.isTrigger = true;
    }

}
