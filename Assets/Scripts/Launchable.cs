using UnityEngine;
using System.Collections;

public class Launchable : MonoBehaviour {
	
	public int DirectHitDamage;
	public int SplashHitDamage;
	public float SightRadius;
	public bool Disabled;
	public bool Landed;
	
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
	
	public void HasLanded()
	{
		Landed = true;
	}
	
	
}
