using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Collider>().isTrigger = true;
	}
	
	void OnTriggerEnter(Collider player) {
		if(player.gameObject.tag == "Player"){
			player.gameObject.GetComponent<CharacterRigidNew>().CheckPointSet(gameObject.transform.position);
		}
	}
}
