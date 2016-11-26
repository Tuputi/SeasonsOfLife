using UnityEngine;
using System.Collections.Generic;

public class SeasonBackdrop : SeasonObject {

    public List<Sprite> backdrop;
    Sprite mySprite;

    void Start()
    {
        mySprite = this.GetComponent<SpriteRenderer>().sprite;
    }
    protected override void _HandleSeasonChange(Season newSeason)
    {
        mySprite = backdrop[(int)newSeason];
    }

    public override bool HandleTriggerEvent(bool enter)
    {
        return false;
    }

    public override void HandleInteraction()
    {
        return;
    }
}
