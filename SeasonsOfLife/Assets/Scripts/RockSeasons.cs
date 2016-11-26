using UnityEngine;
using System.Collections;
using System;

public class RockSeasons : SeasonObject {

    public override void HandleInteraction()
    {
        throw new NotImplementedException();
    }

    public override bool HandleTriggerEvent(bool enter)
    {
        throw new NotImplementedException();
    }

    protected override void _HandleSeasonChange(Season newSeason)
    {
        return;
    }
}
