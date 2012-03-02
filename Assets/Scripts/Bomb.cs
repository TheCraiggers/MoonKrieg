using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	
	public int BlastRadius;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col)
	{
		//TODO: Add explosion graphic / sound.
		col.gameObject.SendMessage("ReceiveDamage",6);
		Collider[] objectsInRange = Physics.OverlapSphere(this.gameObject.transform.localPosition, BlastRadius);
		foreach (Collider Hit in objectsInRange)
		{
			Hit.gameObject.SendMessage("ReceiveDamage",3);
		}
		//Destroy myself
		Destroy(this.gameObject);
	}
}
