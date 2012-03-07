using UnityEngine;
using System.Collections;

public class AntiAir : MonoBehaviour {
	
	public GameObject AntiAirMissile;
	public int DetectionRadius;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void HasLanded()
	{
		//Now that we've landed, add a sphere collision detector that will be the AA's range
		SphereCollider sc = this.gameObject.AddComponent<SphereCollider>();
		sc.isTrigger = true;
		sc.radius = DetectionRadius;
		
		//We also need to set up our clones to also detect for us.
		foreach (Transform child in transform)
		{
			child.gameObject.AddComponent<AntiAirCloneBehavior>();
		}
	}
	
	void OnTriggerEnter(Collider col) 
	{
		//Make sure the object is in the air, and is an enemy
		if (this.gameObject.tag != col.gameObject.tag)
		{
			if (!col.gameObject.GetComponent<Launchable>().Landed)
			{
				LaunchMissile(col.gameObject, Vector3.zero);
			}
		}
	}
	
	void LaunchMissile(GameObject Target, Vector3 Offset)
	{
		//disable the colider and this building
		this.gameObject.SendMessage("DisableMe");
		
		//launch missile
		Debug.Log("Launching missle!");
		GameObject Launched = Instantiate(AntiAirMissile,this.transform.position + new Vector3(0,1,0),this.transform.rotation) as GameObject;
		Physics.IgnoreCollision(this.gameObject.collider,Launched.collider);
		Launched.GetComponent<AntiAirMissileBehavior>().Target = Target;
		Launched.GetComponent<AntiAirMissileBehavior>().Offset = Offset;
		
	}
	
	void DisableMe()
	{
		this.gameObject.GetComponent<SphereCollider>().enabled = false;
	}
	
	void EnableMe()
	{
		this.gameObject.GetComponent<SphereCollider>().enabled = true;
	}
}
