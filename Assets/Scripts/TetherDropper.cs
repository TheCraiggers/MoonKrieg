using UnityEngine;
using System.Collections;

public class TetherDropper : MonoBehaviour {
	
	public GameObject TetherObject;
	public Vector3 ParentOffset = Vector3.zero;
	private bool HasLanded;
	private int NextTetherNumber = 1;
	private GameObject MyParent;
	
	
	// Use this for initialization
	void Start () {
		HubBehavior foo = this.gameObject.GetComponent<HubBehavior>();
		if (foo)
			if (foo.StartingHub)
				Destroy(this);
		MyParent = this.gameObject.GetComponent<FamilyBehavior>().MyParent;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Need to rewrite this so that tethers look right when wrapping around the map.
		
		//Drop tethers as it flies; drop every 2 distance for now
		if ((this.transform.position - MyParent.transform.position - ParentOffset).magnitude > 2) 
		{
			GameObject foo = Instantiate(TetherObject,this.transform.position,this.transform.rotation) as GameObject;
			FamilyBehavior FooFamily = foo.GetComponent<FamilyBehavior>();
			
			MyParent.GetComponent<FamilyBehavior>().MyChildren.Add(foo);
			MyParent.GetComponent<FamilyBehavior>().MyChildren.Remove(this.gameObject);
			
			FooFamily.MyParent = MyParent;
			MyParent = foo;
			this.gameObject.GetComponent<FamilyBehavior>().MyParent = foo;
			FooFamily.MyChildren.Add(this.gameObject);

			Physics.IgnoreCollision(this.collider,MyParent.collider);
			MyParent.name = "Tether";
			MyParent.GetComponent<TetherBehavior>().TetherNumber = NextTetherNumber;
			NextTetherNumber++;
			if (NextTetherNumber > 4)
				NextTetherNumber = 1;
			ParentOffset = Vector3.zero;
				
		}
	
	}
	
	
	void OnCollisionEnter(Collision col) {
		//Just hit something, no matter what it was, I won't be dropping tethers anymore.
		Destroy(this);
	}
}
