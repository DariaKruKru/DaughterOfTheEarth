using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

public class EnemyBehavior : MonoBehaviour {

	private Vector3 startPosition;
	Animator anim;
	private CharacterController enemy;
	Transform player;
	public float range = 4f;
	public float speed = 2f;
	private Vector3 velocity;

	private float currentPosition;

	// Use this for initialization
	void Start () {	
		startPosition = transform.position;
		anim = GetComponent<Animator>();
		enemy = GetComponent<CharacterController>();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		currentPosition = gameObject.transform.position.x;
		float deltaPosition = currentPosition - startPosition.x;
		if (Mathf.Abs(deltaPosition) > range){

			if(deltaPosition > 0){
				currentPosition -=speed;
			}
			else{
				currentPosition +=speed;
			}
		}
		enemy.Move(velocity * Time.deltaTime);
	}
}
