using UnityEngine;
using System.Collections;

public class DeActivate : MonoBehaviour {

    public void DeaactivateNotEnough()
    {
        transform.gameObject.SetActive(false);
    }
}
