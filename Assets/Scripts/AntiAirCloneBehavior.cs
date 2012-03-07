using UnityEngine;
using System.Collections;

public class AntiAirCloneBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SphereCollider sc = this.gameObject.AddComponent<SphereCollider>();
		sc.isTrigger = true;
		sc.radius = this.gameObject.transform.parent.gameObject.GetComponent<AntiAir>().DetectionRadius;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col) 
	{
		//Make sure the object is in the air, and is an enemy
		if (this.gameObject.tag != col.gameObject.tag)
		{
			if (!col.gameObject.GetComponent<Launchable>().Landed)
			{
				/* Since this is just a clone, we will only be notifying the parent about
				 * the detection.  It will take care of launching the missile for us.
				 * Because this is a clone, we already know that the target is near the edge
				 * of the map.  We need to make sure the parent antiair object knows this
				 * and sets its offset accordingly so the missle lockon works.
				 */
				
				
			}
		}
	}
}