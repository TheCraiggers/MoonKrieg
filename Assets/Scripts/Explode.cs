using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public int DirectHitDamage;
	public int SplashHitDamage;
	public int ExplosionRadius;
	
	// Use this for initialization
	void Start () {
		//Assign the explode script to all children
		foreach (Transform child in transform)
		{
			Explode foo = child.gameObject.AddComponent<Explode>();
			foo.DirectHitDamage = DirectHitDamage;
			foo.SplashHitDamage = SplashHitDamage;
			foo.ExplosionRadius = ExplosionRadius;
		}
	}
	
	public void BlowUp()
	{
		//Time to explode!  Wee!
		Collider[] objectsInRange = Physics.OverlapSphere(this.gameObject.transform.position, ExplosionRadius);
		foreach (Collider col in objectsInRange)
	        col.gameObject.SendMessage("ApplyDamage",SplashHitDamage);
	}
	
	
}
