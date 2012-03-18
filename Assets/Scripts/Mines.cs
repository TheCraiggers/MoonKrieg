using UnityEngine;
using System.Collections;

public class Mines : MonoBehaviour {
	
	void ApexDetected()
	{
		//Time to split
		//Code to make the mine that goes off to the left
		GameObject foo = Instantiate(this.gameObject) as GameObject; //,this.transform.position - Vector3.left,this.transform.rotation) as GameObject;
		Physics.IgnoreCollision(this.gameObject.collider, foo.collider);
		foo.rigidbody.velocity = this.rigidbody.velocity;
		foo.rigidbody.AddRelativeForce(Vector3.right * 400);
		
		//Code to make the mine that goes off to the right
		foo = Instantiate(this.gameObject) as GameObject; //,this.transform.position - Vector3.left,this.transform.rotation) as GameObject;
		Physics.IgnoreCollision(this.gameObject.collider, foo.collider);
		foo.rigidbody.velocity = this.rigidbody.velocity;
		foo.rigidbody.AddRelativeForce(Vector3.left * 400);
	}
}
