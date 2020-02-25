using UnityEngine;
using System.Collections;

public class AnimTurn : MonoBehaviour {

	Animation anim;
	public float move;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();

		anim.Play ("idle");
	}
	
	// Update is called once per frame
	void Update () {
	
		//move = Input.GetAxisRaw ("Horizontal");

		if ((move > 0) || (move<0)) {
						anim.Play ("run");
				} else {
						if  ( move == 0f ) {
								anim.Play ("idle");
						}
			}

	}
}
