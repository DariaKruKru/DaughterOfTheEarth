var animationTarget : Animation;

var maxForwardSpeed : float = 6;
var maxBackwardSpeed : float = 3;
var maxSidestepSpeed : float = 4;

private var jumping : boolean = false;
private var minUpwardSpeed = 2;

var character : CharacterController;
var thisTransform : Transform;

function Start(){
	character = GetComponent( CharacterController );
	thisTransform = transform;

	animationTarget.wrapMode = WrapMode.Loop;
	animationTarget["jump"].wrapMode = WrapMode.ClampForever;
	animationTarget["jump-land"].wrapMode = WrapMode.ClampForever;
	animationTarget["run-land"].wrapMode = WrapMode.ClampForever;
	animationTarget["LOSE"].wrapMode = WrapMode.ClampForever;
}

function OnEndGame() {
	this.enabled = false;
}		

function Update() {
		var characterVelocity = character.velocity;
		var horizontalVelocity : Vector3 = characterVelocity;
		horizontalVelocity.y = 0;
		var speed = horizontalVelocity.magnitude;
		var upwardsMotion = Vector3.Dot( thisTransform.up, characterVelocity );
		
		if ( !character.isGrounded && upwardsMotion > minUpwardSpeed )
			jumping = true;
			
		if ( animationTarget.IsPlaying( "run-land" ) && 
				animationTarget[ "run-land" ].normalizedTime < 1.0 && speed > 0 ) {
		} else if ( animationTarget.IsPlaying( "jump-land" ) ) {
				if ( animationTarget[ "jump-land" ].normalizedTime >= 1.0 )
					animationTarget.Play( "idle" );
			} else if ( jumping ) {
					if ( character.isGrounded ) {
						if ( speed > 0 )
							animationTarget.Play( "run-land" );
						else
							animationTarget.Play( "jump-land" );
							jumping = false;
					} else
							animationTarget.Play( "jump" );
			} else if ( speed > 0 ) {
				var forwardMotion = Vector3.Dot( thisTransform.forward, horizontalVelocity );
				var sidewaysMotion = Vector3.Dot( thisTransform.right, horizontalVelocity );
				var t = 0.0;
				if ( Mathf.Abs( forwardMotion ) > Mathf.Abs( sidewaysMotion ) ) {
					if ( forwardMotion > 0 ) {
						t = Mathf.Clamp( Mathf.Abs( speed / maxForwardSpeed ), 0, maxForwardSpeed );
						animationTarget[ "run" ].speed = Mathf.Lerp( 0.25, 1, t );
						if ( animationTarget.IsPlaying( "run-land" ) || animationTarget.IsPlaying( "idle" ) )
							animationTarget.Play( "run" );
						else
							animationTarget.CrossFade( "run" );
						} else {
							t = Mathf.Clamp( Mathf.Abs( speed / maxBackwardSpeed ), 0, maxBackwardSpeed );
							animationTarget[ "run-land" ].speed = Mathf.Lerp( 0.25, 1, t );
							animationTarget.CrossFade( "run-land" );
							}
					} else {
						t = Mathf.Clamp( Mathf.Abs( speed / maxSidestepSpeed ), 0, maxSidestepSpeed );
						if ( sidewaysMotion > 0 ) {
						animationTarget[ "runright" ].speed = Mathf.Lerp( 0.25, 1, t );
						animationTarget.CrossFade( "runright" );
						} else {
						animationTarget[ "runleft" ].speed = Mathf.Lerp( 0.25, 1, t );
						animationTarget.CrossFade( "runleft" );
						}
					}
			} else {
				animationTarget.CrossFade( "idle" );
			}
			

}
	

		

		