using UnityEngine;
using System.Collections;

public class CharacterControler : MonoBehaviour {

    float maxSpeed = 10f;
    bool facingRight = true;

	public float groundRaycastDistance = 2;
	public float rotationSmooth = 10;
	int groundLayers = 0;

	// Use this for initialization
	void Start () {
		string[] groundLayers = new string[] {"Environment"};

		this.groundLayers = LayerMask.GetMask (groundLayers);

		GameObject refgo = new GameObject ();
		refgo.name = "Jus' chillin. Ignore me. (Created from CharacterController)";
		refTransform = refgo.transform;
    }

	void Update(){
	}

    // Update is called once per frame
    void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * move, GetComponent<Rigidbody2D>().velocity.y);

		_GroundRaycast ();
	}

	Transform refTransform;

	protected void _GroundRaycast(){

		RaycastHit2D hit = Physics2D.Raycast(transform.position+(Vector3.up*1f), -Vector2.up, groundRaycastDistance, groundLayers);
		Vector3 normal;
		if (hit.collider != null) {
			float distance = Mathf.Abs (hit.point.y - transform.position.y);
			normal = hit.normal;
		} else {
			normal = Vector3.up;
		}


			

		//float step = rotationSpeed * Time.fixedDeltaTime;

		transform.up = Vector3.Lerp(transform.up, normal, 1/rotationSmooth);

		refTransform.up = normal;


		float rot = Quaternion.Angle(transform.rotation, Quaternion.Euler(Vector3.zero));
		float nRot = Quaternion.Angle(refTransform.rotation, Quaternion.Euler(Vector3.zero));


		if ((Mathf.Abs (rot) < 4) && (Mathf.Abs (nRot) < 4)) {
			transform.up = Vector3.up;
		}
		

	}
}
