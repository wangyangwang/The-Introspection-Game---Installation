using UnityEngine;
using System.Collections;

public class FogControl : MonoBehaviour {


	GameObject fogBoundCube;
	GameObject ovrController;
	public static bool inFog = true;

	float fogChangeRate = 0.01f;

	// Use this for initialization
	void Start () {
		fogBoundCube = GameObject.Find("FogBound");
		ovrController = GameObject.Find("OVRPlayerController");
	}

	// Update is called once per frame
	void Update () {
		if(fogBoundCube.collider.bounds.Contains(ovrController.transform.position)){
			RenderSettings.fogColor = new Color(0.0f,0.0f,0.0f);
		}else{
			Debug.Log ("out of fog///");
			inFog = false;
			if(RenderSettings.fogColor.r < 1){
				float t = RenderSettings.fogColor.r;
				t += fogChangeRate;
				RenderSettings.fogColor = new Color(t,t,t);
			}
		}
	}
}
