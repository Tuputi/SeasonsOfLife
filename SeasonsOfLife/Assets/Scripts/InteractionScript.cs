using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {

   static bool waitingForInput = false;
   static SeasonObject objectWaitingInteraction;
	
    void Update() {
        if (waitingForInput)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractionEvent();
            }
        }
	}

    public static void InteractionPossible(SeasonObject with)
    {
        Debug.Log("Interaction possible");
        waitingForInput = true;
        objectWaitingInteraction = with;
    }

    public static void InteractionCancelled()
    {
        Debug.Log("cancel");
        waitingForInput = false;
        objectWaitingInteraction = null;
    }

    public void InteractionEvent()
    {
        Debug.Log("Event");
        objectWaitingInteraction.HandleInteraction();
        InteractionCancelled();
    }
}
