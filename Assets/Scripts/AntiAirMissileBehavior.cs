using UnityEngine;
using System.Collections;

public class AntiAirMissileBehavior : MonoBehaviour {

	public GameObject Target;
	
	// Use this for initialization
	void Start () {
		Debug.Log("0");
		StartCoroutine(LaunchMe());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private IEnumerator LaunchMe()
	{
		Debug.Log("1");
		this.gameObject.rigidbody.AddRelativeForce(Vector3.up * 500);
		yield return new WaitForSeconds(0.5F);
		Debug.Log("2");
		this.gameObject.transform.LookAt(Target.transform);
		this.gameObject.AddComponent("ConstantForce");
		this.gameObject.constantForce.relativeForce = new Vector3(0F,0F,50F);
	}
	
	void OnCollisionEnter(Collision col)
	{
		col.gameObject.SendMessage("DestroyMe",false);
	}
}
