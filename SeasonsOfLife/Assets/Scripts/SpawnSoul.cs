using UnityEngine;
using System.Collections;
using System;

public class SpawnSoul : SeasonObject {
    public GameObject soulPallero;

    public override bool HandleTriggerEvent(bool enter)
    {
        if (soulPallero != null)
        {
            InteractionScript.InteractionPossible(this);
            return true;
        }
        return false;
    }

    public override void HandleInteraction()
    {
        if (soulPallero != null)
        {
            soulPallero.gameObject.SetActive(true);
            soulPallero.GetComponent<SoulScript>().SetTargets(soulPallero.transform.position, FindObjectOfType<CharacterControler>().gameObject,
                () =>
                {
                    FindObjectOfType<CharacterControler>().soulPoints += 1;
                });
        }
    }

    protected override void _HandleSeasonChange(Season newSeason)
    {
        return;
    }
}
