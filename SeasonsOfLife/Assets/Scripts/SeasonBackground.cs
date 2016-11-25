using UnityEngine;
using System.Collections;

public class SeasonBackground : SeasonObject {


    public override void _HandleSeasonChange(Season newSeason)
    {
        for(int i = 3; i >= 0; i--)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.FindChild(newSeason.ToString()).gameObject.SetActive(true);
        transform.SetAsFirstSibling();
    }
}
