using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FamilyBehavior : MonoBehaviour {
	
	public GameObject MyParent;
	public List<GameObject> MyChildren;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDestroy() {
		//I have been destroyed, destroy my children and parent (if it's a tether)
		//Death animation is already playing, and should be about half-way finished now.
		
		if (MyParent != null) {
			MyParent.GetComponent<FamilyBehavior>().MyChildren.Remove(this.gameObject);
			if (MyParent.name == "Tether")
				Destroy(MyParent,0.5f);
		}
		
		foreach (GameObject foo in MyChildren) {
			Debug.Log("Deleting child named: " +foo.name);
			foo.GetComponent<FamilyBehavior>().MyParent = null;
			Destroy(foo,0.5f);
		}
	}
	
	public void DestroyMe() {
		//This is called to start a chain reaction.
		FreezeFamily();
		//TODO: Begin death animation
		Destroy(this.gameObject,0.5f);
		
	}
	
	public void FreezeChildren() {
		//This will freeze ALL children, and their children, etc
		foreach (GameObject foo in MyChildren) {
			foo.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			if (foo.name == "Tether")
				foo.GetComponent<FamilyBehavior>().FreezeChildren();
			
		}
	}
	
	public void FreezeParents() {
		//This will freeze all objects up to the parent hub
		MyParent.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		if (MyParent.name == "Tether")
			MyParent.GetComponent<FamilyBehavior>().FreezeParents();
	}
	
	public void FreezeFamily() {
		FreezeParents();
		FreezeChildren();
	}
	
	public void SetParent(GameObject NewParent)
	{
		this.MyParent = NewParent;
	}
}
