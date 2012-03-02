using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Terrain MainTerrain;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("MoveCamUp")>0)
			transform.Translate(0,0,1,Space.World);
		if (Input.GetAxis("MoveCamDown")>0)
			transform.Translate(0,0,-1,Space.World);
		if (Input.GetAxis("MoveCamLeft")>0)
			transform.Translate(-1,0,0,Space.World);
		if (Input.GetAxis("MoveCamRight")>0)
			transform.Translate(1,0,0,Space.World);
		
		//wrap camera to other end of world
		if (transform.position.x < 0)
			transform.position += new Vector3(MainTerrain.terrainData.size.x,0,0);
		if (transform.position.x > MainTerrain.terrainData.size.x)
			transform.position -= new Vector3(MainTerrain.terrainData.size.x,0,0);
		
		if (transform.position.z < 0)
			transform.position += new Vector3(0,0,MainTerrain.terrainData.size.z);
		if (transform.position.z > MainTerrain.terrainData.size.z)
			transform.position -= new Vector3(0,0,MainTerrain.terrainData.size.z);
	}
}
