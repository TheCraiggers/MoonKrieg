using UnityEngine;
using System.Collections;

public class TetherBehavior : MonoBehaviour {
	
	public int TetherNumber; //Number from 1 to 4.  Controls the animation and helps show direction of parent
	private bool HasLanded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Bridge")
		{	
			//object hit ground, freeze it in place
			this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotation;
			this.HasLanded = true;

		}
		else if (col.gameObject.tag == "Water")
		{
			//Object hit water.  If it hits this, object is destroyed.
			this.gameObject.GetComponent<FamilyBehavior>().DestroyMe();
		}
		else
		{
			//Looks like something else.  If I haven't already landed, destroy me.
			if (!HasLanded)
				this.gameObject.GetComponent<FamilyBehavior>().DestroyMe();
		}
    }
	
}
