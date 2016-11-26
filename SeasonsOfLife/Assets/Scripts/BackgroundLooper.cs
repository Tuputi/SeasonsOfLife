using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

	GameObject leftCopy;
	GameObject rightCopy;

	CharacterControler player;

	float spriteWidth;

	public float playerFollowSpeed = 0;

	Vector3 playerLastPos;


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

		leftCopy.transform.parent = this.transform.parent;
		rightCopy.transform.parent = this.transform.parent;

		leftCopy.transform.position += Vector3.left * spriteWidth;
		rightCopy.transform.position += Vector3.right * spriteWidth;


		leftCopy.GetComponent<SpriteRenderer> ().sprite = thisSprite.sprite;
		rightCopy.GetComponent<SpriteRenderer> ().sprite = thisSprite.sprite;

		playerLastPos = player.transform.position;

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
			Vector3 playerVel = player.transform.position - playerLastPos;
			playerLastPos = player.transform.position;
			float followDirX = (playerVel.x) * playerFollowSpeed;
			Vector3 followDir = new Vector3 (followDirX, 0, 0);
			transform.position += followDir;
			leftCopy.transform.position += followDir;
			rightCopy.transform.position += followDir;
		}

	}
}
