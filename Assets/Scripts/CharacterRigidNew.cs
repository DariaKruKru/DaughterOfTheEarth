using UnityEngine;
using System.Collections;


public class CharacterRigidNew : MonoBehaviour {

	
	public ScreenFader screenFader;
	public float speed = 6f;
	public float jumpSpeed = 8f;
	public float move;
	private Vector3 velocity;

	AudioSource stepSound;
	
	//Animator anim;
	public float score;
	bool LookR = true;
	Quaternion rotation;
	Vector3 checkPoint;
	bool isDie = false;

	Rigidbody playerRigidbody;
	
	public bool isGrounded = false;

	float distToGround;
	//public JoystickNew moveJoystick ;	
	public CNJoystick movementJoystick;
	public GameObject Hero;

	// initialization 
	void Start () {

#if UNITY_STANDALONE_WIN

	movementJoystick.Disable();
#endif


		//anim = GetComponent<Animator>();
		stepSound = GetComponent<AudioSource>();
		checkPoint = transform.position;

		playerRigidbody = GetComponent<Rigidbody> ();
		distToGround = GetComponent<Collider>().bounds.extents.y;

		GameObject spawn = GameObject.Find( "PlayerSpawn" );
		if ( spawn )
			playerRigidbody.position = spawn.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		IsGrounded();

#if UNITY_STANDALONE_WIN

		move = Input.GetAxisRaw ("Horizontal");

		if (isGrounded && (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space))) {
			playerRigidbody.velocity =(new Vector3(0f, jumpSpeed, 0f));
		}

#endif

#if UNITY_IOS

		move = movementJoystick.GetAxis("Horizontal");
			
		if ((movementJoystick.GetAxis("Vertical") > 0.1f) && isGrounded){
			playerRigidbody.velocity =(new Vector3(0f, jumpSpeed, 0f));
		}
	
#endif

#if UNITY_WP8

		move = movementJoystick.GetAxis("Horizontal");
		
		if ((movementJoystick.GetAxis("Vertical") > 0.1f) && isGrounded){
			playerRigidbody.velocity =(new Vector3(0f, jumpSpeed, 0f));
		}
		
#endif
		FaceDirection(move);
		Hero.GetComponent<AnimTurn> ().move = move;

		if ( (move != 0f) && (isGrounded)) {
			stepSound.enabled = true;

		} else {
			stepSound.enabled = false;
		}				
					
		playerRigidbody.velocity = new Vector3 (move * speed, playerRigidbody.velocity.y, 0f);

		if (Input.GetKey(KeyCode.Escape)) 
		{ Application.LoadLevel("Menu"); } 
	}


	void OnTriggerEnter(Collider col){
		if ((col.gameObject.tag == "DieCollider") || (col.gameObject.name == "icicle")) {
			Invoke( "Death" , 0.7f);
		}

		if (col.gameObject.tag == "Bonus") {
			score++;
			Destroy (col.gameObject);
			screenFader.fadeState = ScreenFader.FadeState.In;
			Invoke ("Final", 1);
		}

		}

	void Death(){
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		gameObject.transform.position = checkPoint ;
		//Handheld.Vibrate();
	}

	public void CheckPointSet (Vector3 newCheckPoint){
				checkPoint = newCheckPoint;
	}


	void Flip(){
		LookR = !LookR;
		rotation = playerRigidbody.transform.localRotation;
		rotation.y *= -1;
		playerRigidbody.transform.localRotation = rotation;
	}

	void FaceDirection(float h){
	
		if ((h > 0) & !LookR) {
			Flip ();
		}
		else if ((h < 0) & LookR) {
			Flip ();
		}		
	}
	
	void IsGrounded(){
		if (Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.05f)) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	}


	void Final(){

		Application.LoadLevel("Menu");
	}

}
