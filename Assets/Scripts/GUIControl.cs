using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		
	   if (GUI.Button(new Rect(10, 10, 50, 50), "<<<"))
            Debug.Log("Clicked the button with an image");
        
		if (GUI.Button(new Rect(10, 70, 50, 50), ">>>"))
            Debug.Log("Clicked the button with text");
		
		if (GUI.Button(new Rect(10, 140, 50, 50), "Fire")) {
        	GameObject MyHub = GameObject.Find("Hub");
			MyHub.GetComponent<HubBehavior>().Fire();
		}
	}
}
