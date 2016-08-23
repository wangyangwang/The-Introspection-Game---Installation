using UnityEngine;
using System.Collections;

public class fadeInFogColor : MonoBehaviour {


		public float timeTillTransitionStart = 5.0f;
		public float transitionTime = 5.0f;
		Color originalFogColor;
		float counter = 0.0f;

		float initThickFogDensity = 0.001f;
		float normalFogDensity = 0.00038f; //normal
		float densityFadeInRate;
		public float densityFadeInTime;

		void Awake(){
			originalFogColor = RenderSettings.fogColor;
		}

		// Use this for initialization
		void Start () {
			RenderSettings.fogDensity = initThickFogDensity;
			RenderSettings.fogColor = Color.white;
			densityFadeInRate = (normalFogDensity - initThickFogDensity) / densityFadeInTime ;
		}
		
		// Update is called once per frame
		void Update () {

			if(counter < 1){
				counter += 0.015f * Time.deltaTime;
			}

			if(Time.time >= timeTillTransitionStart && RenderSettings.fogColor != originalFogColor){
				RenderSettings.fogColor = Color.Lerp(Color.white,  originalFogColor, counter );
		}


		//density
		if(RenderSettings.fogDensity > normalFogDensity){
			float d = RenderSettings.fogDensity;
			d += densityFadeInRate * Time.deltaTime;
			RenderSettings.fogDensity = d;
		}

	}
}
