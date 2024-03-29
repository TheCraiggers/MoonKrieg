
var fogOfWar : GameObject;
private var fogOfWarMesh : Mesh;
private var fogOfWarScript : FogOfWar;

function Start()
{
	fogOfWarMesh = fogOfWar.GetComponent(MeshFilter).mesh;
	fogOfWarScript = fogOfWar.GetComponent(FogOfWar);

}

function HideOrShow()
{
	var x = transform.position.x;
	var z = transform.position.z;

	var hit : RaycastHit;
	var layerMask = 1 << 8; // layer 8 is where the fog of war is

	Debug.DrawRay(Vector3(x,FogOfWar.RAYCAST_HEIGHT,z), -Vector3.up*FogOfWar.RAYCAST_HEIGHT);
	if (!Physics.Raycast(Vector3(x,FogOfWar.RAYCAST_HEIGHT,z), -Vector3.up, hit, Mathf.Infinity, layerMask))
	{
		//Debug.Log("raycast did not hit anything");
		return;
	}
	// Just in case, also make sure the collider also has a renderer
	// material and texture
	var meshCollider = hit.collider as MeshCollider;
	if (meshCollider == null || meshCollider.sharedMesh == null)
	{
		return;
	}

	//Debug.Log(hit.collider.gameObject.name);


	// here it is assumed that what we hit is the fog of war mesh, so we use it
	// directly and not hit.collider.gameObject.GetComponent(MeshFilter).mesh;
	var triangles = fogOfWarMesh.triangles;

	// get which vertices were hit
	var p0 = triangles[hit.triangleIndex * 3 + 0];
	var p1 = triangles[hit.triangleIndex * 3 + 1];
	var p2 = triangles[hit.triangleIndex * 3 + 2];

	if (fogOfWarScript.IsVertRevealed(p0) && fogOfWarScript.IsVertRevealed(p1) && fogOfWarScript.IsVertRevealed(p2))
	{
		SendMessage("Show");
	}
	else
	{
		SendMessage("Hide");
	}
}

function Update ()
{
	HideOrShow();
}
