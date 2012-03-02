using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	
	public int MaxHP;
	public int CurrentHP;
	public int OnDestroyDamage;
	public int OnDestroyDamageRadius;
	
	
	
	
	private int NextTetherNumber = 1;

	// Use this for initialization
	void Start () {
		CurrentHP = MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ReceiveDamage(int Damage)
	{
		CurrentHP = CurrentHP - Damage;
		if (CurrentHP <= 0)
		{
			Destroy(this.gameObject);
		}
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
			//Object his water.  If it hits this, object is destroyed.
			Debug.Log("Hit Water!");
			//TODO: Added water sound / gfx effect
			this.gameObject.SendMessage("HasHitWater");
		}
        
    }
		
}
