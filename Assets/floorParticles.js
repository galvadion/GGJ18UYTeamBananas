#pragma strict

function Start () {
	
}

function Update () {
	
}

function playParticules(par: GameObject){
	instantiate(par,transform.position,transform.rotation);
}