using UnityEngine;
using System.Collections;

public class DetectApex : MonoBehaviour {

	private float LastY;
	
	// Update is called once per frame
	void Update () {
		if (LastY > this.transform.position.y)
		{
			Destroy(this);  //Won't need to ever detect the apex again, so remove script.
			this.gameObject.SendMessage("ApexDetected");
		}
		else
			LastY = this.transform.position.y;
	}
}
