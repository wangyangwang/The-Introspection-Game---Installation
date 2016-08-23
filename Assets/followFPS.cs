using UnityEngine;
using System.Collections;

public class followFPS : MonoBehaviour {

	bool following = false;
	GameObject fogBoundCube;
	GameObject ovrController;


	void OnEnable(){
		Emit.c3MissionComplished += turnOnFollowing;
	}

	void OnDisable(){
		Emit.c3MissionComplished -= turnOnFollowing;
	}

	// Use this for initialization
	void Start () {
		fogBoundCube = GameObject.Find("FogBound");
		ovrController = GameObject.Find("OVRPlayerController");

	}
	
	// Update is called once per frame
	void Update () {
		if(following){
			gameObject.transform.position = new Vector3(0,-500,0);
		}
//		if(!fogBoundCube.collider.bounds.Contains(ovrController.transform.position)){
//			turnOffFollowing();
//		}
	}
	

	void turnOnFollowing(){
		following = true;
	}

	void turnOffFollowing(){
		following = false;
	}

}
