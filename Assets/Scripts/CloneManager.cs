using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloneManager : MonoBehaviour {

	/* This script handles copying the object to all 8 cloned terrains
	 * and keeping everything in sync.
	 * 
	 * Most of this will be handled automatically through the use of
	 * child objects attached to the main copy.  This script handles
	 * the creation of these clones, linking them to their parents,
	 * and removing all unneeded scripts from them.
	 */
	
	private Terrain MainTerrain;
	public GameObject ClonePrefab;
	
	// Use this for initialization
	void Start () {
		
		List<Vector3> VectorList = new List<Vector3>();
		
		MainTerrain = GameObject.Find("Main Camera").GetComponent<CameraMove>().MainTerrain;
		
		//Looks like a new object was just created.  Create the clones.
		
		//First step is to create a list of Vector3 objects which will
		//aid in moving the clones to the exact right spot upon creation
		
		//upper left
		VectorList.Add(new Vector3(-MainTerrain.terrainData.size.x,0,-MainTerrain.terrainData.size.z));
		//upper middle
		VectorList.Add(new Vector3(0,0,-MainTerrain.terrainData.size.z));
		//upper right
		VectorList.Add(new Vector3(MainTerrain.terrainData.size.x,0,-MainTerrain.terrainData.size.z));
		
		//Middle left
		VectorList.Add(new Vector3(-MainTerrain.terrainData.size.x,0,0));
		//Middle Right
		VectorList.Add(new Vector3(MainTerrain.terrainData.size.x,0,0));
		
		//Lower Left
		VectorList.Add(new Vector3(-MainTerrain.terrainData.size.x,0,MainTerrain.terrainData.size.z));
		//Lower Middle
		VectorList.Add(new Vector3(0,0,MainTerrain.terrainData.size.z));
		//Lower Right
		VectorList.Add(new Vector3(MainTerrain.terrainData.size.x,0,MainTerrain.terrainData.size.z));
		
		
		//Now loop though, creating clones along the way
		foreach(Vector3 fooVector in VectorList) {
			GameObject foo = Instantiate(ClonePrefab,this.gameObject.transform.localPosition + fooVector,this.transform.rotation) as GameObject;
			//Assign to parent
			foo.transform.parent = 	this.gameObject.transform;
			foo.GetComponent<MeshFilter>().mesh = this.gameObject.GetComponent<MeshFilter>().sharedMesh;
			foo.GetComponent<MeshRenderer>().materials = this.gameObject.GetComponent<MeshRenderer>().sharedMaterials;
			

		
		}
	
	}
}
