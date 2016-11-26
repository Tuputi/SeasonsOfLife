using UnityEngine;
using System.Collections;

public class CharacterControler : MonoBehaviour {

    float maxSpeed = 10f;
    bool facingRight = true; 
	// Use this for initialization
	void Start () {



    }

    // Update is called once per frame
    void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * move, GetComponent<Rigidbody2D>().velocity.y);
	
	}
}
