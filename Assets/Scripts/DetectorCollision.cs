using UnityEngine;
using System.Collections;

public class DetectorCollision : MonoBehaviour {
	public GameObject Icicle;	

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.name == "Player")
		{
			Icicle.GetComponent<IcicleBehavior>().IcicleFall();
		}
		
	}

}
