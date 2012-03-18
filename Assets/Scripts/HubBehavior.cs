using UnityEngine;
using System.Collections;

public class HubBehavior : MonoBehaviour {
	
	//List of various prefabs that are possible to launch
	//1 Energy
	public GameObject Bomb;
	public GameObject Repair;
	public GameObject ClusterBomb;
	public GameObject Tower;
	public GameObject AntiAir;
	public GameObject Bridge;
	//3 Energy
	public GameObject Spike;
	public GameObject Missile;
	public GameObject Balloon;
	public GameObject Mines;
	public GameObject EMP;
	public GameObject Reclaim;
	//5 Energy
	public GameObject Hub;
	public GameObject Offense;
	public GameObject Crawler;
	public GameObject Virus;
	public GameObject Collector;
	public GameObject Shield;
	
	public bool OffensiveHub = false;
	public int Player;
	public bool StartingHub = false;
	
	private GameObject Wind;
	private bool IsFiring;
	

	// Use this for initialization
	void Start () {
		Wind = GameObject.Find("Wind");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Fire() {
		GameObject Launched = Instantiate(Mines,this.transform.position + new Vector3(0,1,0),this.transform.rotation) as GameObject;
		Physics.IgnoreCollision(this.gameObject.collider,Launched.collider);
		Launched.SendMessage("SetParent",this.gameObject);
		Launched.rigidbody.AddRelativeForce(Vector3.up * 500);
		Launched.rigidbody.AddRelativeForce(Vector3.back * 500);
		//Wind is applied via a constant force.  It uses the Wind game object's potition as the direction.
		Launched.AddComponent("ConstantForce");
		Launched.constantForce.relativeForce = Wind.transform.position;
	}
}
