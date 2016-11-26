using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

    private SeasonObject parent;

    void Start()
    {
        parent = transform.parent.GetComponent<SeasonObject>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        parent.HandleTriggerEvent(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        parent.HandleTriggerEvent(false);
    }
}
