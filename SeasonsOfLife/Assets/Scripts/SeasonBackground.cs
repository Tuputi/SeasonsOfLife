using UnityEngine;
using System.Collections;
using System;

public class SeasonBackground : SeasonObject {


    protected override void _HandleSeasonChange(Season newSeason)
    {
        for(int i = 3; i >= 0; i--)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.FindChild(newSeason.ToString()).gameObject.SetActive(true);
        transform.SetAsFirstSibling();
    }

    public override bool HandleTriggerEvent(bool enter)
    {
        throw new NotImplementedException();
    }

    public override void HandleInteraction()
    {
        throw new NotImplementedException();
    }
}
