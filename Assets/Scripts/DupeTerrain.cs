using UnityEngine;
using System.Collections;

public class DupeTerrain : MonoBehaviour {
	
	public Terrain MainTerrain;
	private Terrain T;
	private Terrain B;
	private Terrain L;
	private Terrain R;
	private Terrain TL;
	private Terrain TR;
	private Terrain BL;
	private Terrain BR;
	
	// Use this for initialization
	void Start () {
		
		
		R = Instantiate(MainTerrain) as Terrain;
		R.transform.position = new Vector3(MainTerrain.terrainData.size.x,0,0);
		L = Instantiate(MainTerrain) as Terrain;
		L.transform.position = new Vector3(-MainTerrain.terrainData.size.x,0,0);
		T = Instantiate(MainTerrain) as Terrain;
		T.transform.position = new Vector3(0,0,MainTerrain.terrainData.size.z);
		B = Instantiate(MainTerrain) as Terrain;
		B.transform.position = new Vector3(0,0,-MainTerrain.terrainData.size.z);
		
		TR = Instantiate(MainTerrain) as Terrain;
		TR.transform.position = new Vector3(MainTerrain.terrainData.size.x,0,MainTerrain.terrainData.size.z);
		BR = Instantiate(MainTerrain) as Terrain;
		BR.transform.position = new Vector3(MainTerrain.terrainData.size.x,0,-MainTerrain.terrainData.size.z);
		TL = Instantiate(MainTerrain) as Terrain;
		TL.transform.position = new Vector3(-MainTerrain.terrainData.size.x,0,MainTerrain.terrainData.size.z);
		BL = Instantiate(MainTerrain) as Terrain;
		BL.transform.position = new Vector3(-MainTerrain.terrainData.size.x,0,-MainTerrain.terrainData.size.z);
		
		TL.SetNeighbors(null,null,T,L);
		T.SetNeighbors(TL,null,TR,MainTerrain);
		TR.SetNeighbors(T,null,null,R);
		L.SetNeighbors(null,TL,MainTerrain,BL);
		MainTerrain.SetNeighbors(L,T,R,B);
		R.SetNeighbors(MainTerrain,TR,null,BR);
		BL.SetNeighbors(null,L,B,null);
		B.SetNeighbors(BL,MainTerrain,BR,null);
		BR.SetNeighbors(B,R,null,null);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
