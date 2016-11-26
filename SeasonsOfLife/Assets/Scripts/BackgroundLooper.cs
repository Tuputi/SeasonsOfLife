using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

	GameObject leftCopy;
	GameObject rightCopy;

	CharacterControler player;

	float spriteWidth;

	public float playerFollowSpeed = 0;

	void Start () {
		leftCopy = new GameObject ();
		rightCopy = new GameObject ();

		SpriteRenderer thisSprite = GetComponent<SpriteRenderer> ();

		player = FindObjectOfType<CharacterControler> ();

		spriteWidth = thisSprite.bounds.size.x / transform.localScale.x;

		leftCopy.AddComponent<SpriteRenderer> ();
		rightCopy.AddComponent<SpriteRenderer> ();

		leftCopy.transform.position = this.transform.position;
		rightCopy.transform.position = this.transform.position;

		leftCopy.transform.position += Vector3.left * spriteWidth;
		rightCopy.transform.position += Vector3.right * spriteWidth;


		leftCopy.GetComponent<SpriteRenderer> ().sprite = thisSprite.sprite;
		rightCopy.GetComponent<SpriteRenderer> ().sprite = thisSprite.sprite;

	}


	void Update () {
		if (player.transform.position.x > transform.position.x + spriteWidth / 2) {
			transform.position += transform.right * spriteWidth;
			leftCopy.transform.position += Vector3.right * spriteWidth;
			rightCopy.transform.position += Vector3.right * spriteWidth;
		} else if (player.transform.position.x < transform.position.x - spriteWidth / 2) {
			transform.position -= transform.right * spriteWidth;
			leftCopy.transform.position -= Vector3.right * spriteWidth;
			rightCopy.transform.position -= Vector3.right * spriteWidth;
		}
	}

	void FixedUpdate() {
		if (playerFollowSpeed != 0) {
			float followDirX = (player.GetComponent<Rigidbody2D> ().velocity.x * Time.fixedDeltaTime) * playerFollowSpeed;
			Vector3 followDir = new Vector3 (followDirX, 0, 0);
			transform.position += followDir;
			leftCopy.transform.position += followDir;
			rightCopy.transform.position += followDir;
		}

	}
}
