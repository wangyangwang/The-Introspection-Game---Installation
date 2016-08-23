using UnityEngine;
using System.Collections;

public class Chapter2FadeIn : MonoBehaviour {



	public float fadeRate;
	public float fadeInTime = 10.0f;
	float currentFogDensity;

	// Use this for initialization
	void Start () {
		currentFogDensity = myParameters.c2StartFogDensity;
		RenderSettings.fogDensity = currentFogDensity;
		fadeRate = (myParameters.c2NormalFogDensity - currentFogDensity) / fadeInTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad  > myParameters.c2TimeUntillEverythingFadeIn){
			if(currentFogDensity > myParameters.c2NormalFogDensity){
				currentFogDensity += fadeRate * Time.deltaTime;
				RenderSettings.fogDensity = currentFogDensity;
			}
		}
	}
}
