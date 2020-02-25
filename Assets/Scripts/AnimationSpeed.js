#pragma strict

var animationTarget : Animation;
var speed = 1.0;
function Start() {
	animationTarget[ animationTarget.clip.name ].speed = speed;
}