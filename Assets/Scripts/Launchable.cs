using UnityEngine;
using System.Collections;

public class Launchable : MonoBehaviour {
	
	public float SightRadius;
	public bool Disabled;
	public bool Landed;
	public Vector3 MyOffset;
	
	// Use this for initialization
	void Start () {
		Disabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void UpdateFOW() {
		
	}
	
	public void DestroyMe(bool ShouldExplode)
	{
		DestroyObject(this.gameObject);
		//TODO: Add mini explosion effect
		//TODO: Remove parent tether
		//TODO: Remove child tethers, destroy those targets
		//TODO: Remove Fog of War clearing bits.
	}
	
	public void DisableMe()
	{
			
	}
	
	void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground")
		{
			//TODO: Detect if the object landed on flat terrain or hit a cliff
			Debug.Log("Start Hit...");
			foreach (ContactPoint contact in col.contacts) {
				Debug.Log(contact.normal);
			}
			Debug.Log("END Hit...");
			
			//object hit ground, freeze it in place & notify scripts
			this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
			this.gameObject.SendMessage("HasLanded");
		}
		if (col.gameObject.tag == "Water")
		{
			//Object hit water.  If it hits this, object is (usually) destroyed.
			Debug.Log("Hit Water!");
			//TODO: Added water sound / gfx effect
			this.gameObject.SendMessage("HasHitWater");
		}
        
    }
	
	public void HasLanded()
	{
		Landed = true;
	}
	
	
}
