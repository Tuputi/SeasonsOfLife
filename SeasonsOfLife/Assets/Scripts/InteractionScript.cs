using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {

   static bool waitingForInput = false;
   static SeasonObject objectWaitingInteraction;
   public GameObject InteractPrompt;
   static GameObject myInteractiPrompt;
   public Animator charaAnim;


    void Start()
    {
        myInteractiPrompt = InteractPrompt;
        myInteractiPrompt.SetActive(false);
    }

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

        myInteractiPrompt.SetActive(true);

        Vector3 temp = Camera.main.WorldToScreenPoint(with.transform.position);
        myInteractiPrompt.transform.position = new Vector3(temp.x, 100, 0);
        myInteractiPrompt.transform.SetAsLastSibling();
        
    }

    public static void InteractionCancelled()
    {
        Debug.Log("cancel");
        myInteractiPrompt.SetActive(false);
        waitingForInput = false;
        objectWaitingInteraction = null;
    }

    public void InteractionEvent()
    {
        Debug.Log("Event");
        charaAnim.Play("Interacting",0);
        objectWaitingInteraction.HandleInteraction();
        InteractionCancelled();
    }
}
