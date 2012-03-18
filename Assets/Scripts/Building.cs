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
	
	void ApplyDamage(int Damage)
	{
		CurrentHP = CurrentHP - Damage;
		if (CurrentHP <= 0)
		{
			Destroy(this.gameObject);
		}
	}
		
}
