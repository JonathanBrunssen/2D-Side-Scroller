using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
	float speedX = 1;
	float jumpForce = 700;
	float speed = 6;
	//int lives = 4;

	//public Text livesText;

	public bool isGrounded;

	Rigidbody2D rb;
	PlayerAnimation playerAnimator;
	// Use this for initialization
	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<PlayerAnimation> ();
		//livesText.text = "Lives: " + lives;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		/*if (pos.y < -24) {
			//lives--;
			if (lives <= 0) {
				SceneManager.LoadScene ("Menu");
			}
			//livesText.text = "Lives: " + lives;
			transform.position = GameObject.Find ("SpawnPoint").transform.position;
		}*/
		MovePlayer (speed);
		if (Input.GetKey (KeyCode.A)) {
			SetFacing (false);
			speed = -speedX;
		}
		if (Input.GetKey (KeyCode.D)) {
			SetFacing (true);
			speed = speedX;
		}
		if (!Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
			speed = 0;
		}
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			playerAnimator.Jump ();
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
			isGrounded = false;
		}
	}
	void MovePlayer(float playerSpeed){
		if (playerSpeed != 0) {
			playerAnimator.Walk ();
		}
		if (playerSpeed == 0) {
			playerAnimator.Idle ();
		}
		rb.velocity = new Vector3 (speed, rb.velocity.y, 0);
	}
	void SetFacing(bool right){
		Vector3 temp = transform.localScale;
		if (right && temp.x < 0 || !right && temp.x > 0) {
			temp.x *= -1;
			transform.localScale = temp;
		}
	}
}
