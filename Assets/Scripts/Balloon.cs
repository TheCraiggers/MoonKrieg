using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
	
	private Building LaunchControl;
	private float LastY;
	private bool ApexFound;
	

	// Use this for initialization
	void Start () {
		LaunchControl = this.GetComponent<Building>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//While flying, detect apex
		if (!ApexFound)
			if (LastY > this.transform.position.y)
				ApexDetected();
			else
				LastY = this.transform.position.y;
				
			
		
	}
	
	void ApexDetected() {
		ApexFound = true;
		
		//This is a balloon, so stop movement in mid-air and apply bounce affect.
		rigidbody.useGravity = false;
		rigidbody.drag = 5;
		iTween.MoveTo(this.gameObject,iTween.Hash("y",this.rigidbody.position.y+.5,"time",20,"looptype",iTween.LoopType.pingPong,"easetype",iTween.EaseType.easeInOutBack));
		
	}
}
