using UnityEngine;
using System.Collections;

public class C3FogFadeIn : MonoBehaviour {


	public float fadeInRate;
	public float fadeInTime;
	public bool fogFadeInFinished = false;


	// Use this for initialization
	void Start () {
		RenderSettings.fogDensity = myParameters.c3StartFogDensity;
		fadeInRate = (myParameters.c3NormalFogDensity - myParameters.c3StartFogDensity) / fadeInTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(RenderSettings.fogDensity >= myParameters.c3NormalFogDensity && !fogFadeInFinished){
			float temp = RenderSettings.fogDensity;
			temp += fadeInRate * Time.deltaTime;
			RenderSettings.fogDensity = temp;
		}

		if(RenderSettings.fogDensity < myParameters.c3NormalFogDensity){
			fogFadeInFinished = true;
		}
	}
}
