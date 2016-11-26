using UnityEngine;
using System.Collections;

public class CharacterControler : MonoBehaviour {

    float maxSpeed = 10f;
    bool facingRight = true;
    Animator anim;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * move, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight) flip();
        else if (move < 0 && facingRight) flip();
	
	}

    void flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale; 

    }
}
