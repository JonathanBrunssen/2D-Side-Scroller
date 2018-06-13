using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void Jump(){
		anim.SetTrigger ("Jumping");
	}
	public void Walk(){
		anim.SetBool ("Idle", false);
		anim.SetBool ("Walking", true);
	}
	public void Idle(){
		anim.SetBool ("Idle", true);
		anim.SetBool ("Walking", false);
	}
}
