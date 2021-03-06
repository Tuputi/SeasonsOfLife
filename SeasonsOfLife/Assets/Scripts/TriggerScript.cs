﻿using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

    private SeasonObject parent;


    void Start()
    {
        parent = transform.parent.GetComponent<SeasonObject>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
		if(other.gameObject.GetComponent<CharacterControler>()!=null)
        	parent.HandleTriggerEvent(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
		if(other.gameObject.GetComponent<CharacterControler>()!=null)
        	parent.HandleTriggerEvent(false);
    }
}
