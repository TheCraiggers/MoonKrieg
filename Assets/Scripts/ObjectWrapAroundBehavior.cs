using UnityEngine;
using System.Collections;

public class ObjectWrapAroundBehavior : MonoBehaviour {

	private Terrain MainTerrain;
	
	// Use this for initialization
	void Start () {
		MainTerrain = GameObject.Find("Main Camera").GetComponent<CameraMove>().MainTerrain;
	}
	
	// Update is called once per frame
	void Update () {
		//wrap to other end of world
		if (transform.position.x < 0){ 
			transform.position += new Vector3(MainTerrain.terrainData.size.x,0,0);
			gameObject.GetComponent<TetherDropper>().ParentOffset += new Vector3(MainTerrain.terrainData.size.x,0,0);
			gameObject.GetComponent<Launchable>().MyOffset += new Vector3(MainTerrain.terrainData.size.x,0,0);
		}
		if (transform.position.x > MainTerrain.terrainData.size.x) {
			transform.position -= new Vector3(MainTerrain.terrainData.size.x,0,0);
			gameObject.GetComponent<TetherDropper>().ParentOffset += new Vector3(-MainTerrain.terrainData.size.x,0,0);
			gameObject.GetComponent<Launchable>().MyOffset += new Vector3(-MainTerrain.terrainData.size.x,0,0);
		}
		
		if (transform.position.z < 0) {
			transform.position += new Vector3(0,0,MainTerrain.terrainData.size.z);
			gameObject.GetComponent<TetherDropper>().ParentOffset += new Vector3(0,0,MainTerrain.terrainData.size.z);
			gameObject.GetComponent<Launchable>().MyOffset += new Vector3(0,0,MainTerrain.terrainData.size.z);
		}
		if (transform.position.z > MainTerrain.terrainData.size.z) {
			transform.position -= new Vector3(0,0,MainTerrain.terrainData.size.z);
			gameObject.GetComponent<TetherDropper>().ParentOffset += new Vector3(0,0,-MainTerrain.terrainData.size.z);
			gameObject.GetComponent<Launchable>().MyOffset += new Vector3(0,0,-MainTerrain.terrainData.size.z);
		}
	}
	
	void OnCollisionEnter(Collision col) {
		//Just hit something, no matter what it was, I won't be moving much anymore so dedstroy this script
		//TODO: Might have to change this to a message-based trigger, as crawlers DO move after hitting ground
		Destroy(this);
	}
}
