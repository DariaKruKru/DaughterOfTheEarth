using UnityEngine;
using System.Collections;

public class IcicleBehavior : MonoBehaviour {
	Rigidbody icicleRigidbody;

	void Start () {
		icicleRigidbody = GetComponent<Rigidbody>();
		icicleRigidbody.isKinematic = true;
	}
	
	public void IcicleFall(){
		icicleRigidbody.isKinematic = false;
		icicleRigidbody.velocity = new Vector3 (0, -0.5f, 0f);
	}
}