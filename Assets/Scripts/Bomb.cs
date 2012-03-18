using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col)
	{
		//TODO: Add explosion graphic / sound.
		//Assign damage to whatever we hit.
		if (col.gameObject != null)
			col.gameObject.SendMessage("ApplyDamage",this.gameObject.GetComponent<Explode>().DirectHitDamage);
		this.gameObject.SendMessage("BlowUp");

		//Destroy myself
		Destroy(this.gameObject);
	}
}
