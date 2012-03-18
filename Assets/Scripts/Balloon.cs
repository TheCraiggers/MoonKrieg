using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	
	void ApexDetected() {
		//This is a balloon, so stop movement in mid-air and apply bounce affect.
		rigidbody.useGravity = false;
		rigidbody.drag = 5;
		iTween.MoveTo(this.gameObject,iTween.Hash("y",this.rigidbody.position.y+.5,"time",20,"looptype",iTween.LoopType.pingPong,"easetype",iTween.EaseType.easeInOutBack));
		
	}
}
