using UnityEngine;
using System.Collections;

public class AntiAirMissileBehavior : MonoBehaviour {

	public GameObject Target;
	public Vector3 Offset;
	
	private Launchable TargetLaunchable;
	private bool Seeking = false;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(LaunchMe());
		TargetLaunchable = Target.GetComponent<Launchable>();
	}
	
	// Update is called once per frame
	void Update () {
		//Has the target been destroyed by some other means?  If so, I explode.
		if (Target == null)
			Destroy(gameObject);
		
		//Have missile look at target
		if (Seeking)
			this.gameObject.transform.LookAt(Target.transform.position - TargetLaunchable.MyOffset);
	}
	
	private IEnumerator LaunchMe()
	{
		this.gameObject.rigidbody.AddRelativeForce(Vector3.up * 500);
		yield return new WaitForSeconds(0.5F);
		Seeking = true;
		this.gameObject.AddComponent("ConstantForce");
		this.gameObject.constantForce.relativeForce = new Vector3(0F,0F,20F);
	}
	
	void OnCollisionEnter(Collision col)
	{
		col.gameObject.SendMessage("DestroyMe",false);
		Destroy(gameObject);
	}
}
