using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour {
	public PlayerManager parent;
	CircleCollider2D collider;
	int amount = 0;
	// Use this for initialization;
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Ground") {
			amount++;
			if (amount > 0) {
				parent.isGrounded = true;
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.tag == "Ground") {
			amount--;
			if (amount == 0) {
				parent.isGrounded = false;
			}
		}
	}
}
