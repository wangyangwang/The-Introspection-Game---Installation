using UnityEngine;
using System.Collections;

public class heartBeatMe : MonoBehaviour {

	Vector3 fadeOutSpeedVec;
	Vector3 originalSize;
	float lightOriginalIntensity;
	float lightOriginalRange;
	public GameObject pointLight;


	void OnEnable(){
		PulseDataProcessor.heartJustBeat += beatMe;
	}

	void OnDisable(){
		PulseDataProcessor.heartJustBeat -= beatMe;
	}

	void Start () {
		fadeOutSpeedVec = new Vector3(myParameters.heartScaleFadeOutSpeed,myParameters.heartScaleFadeOutSpeed,myParameters.heartScaleFadeOutSpeed);
		originalSize = gameObject.transform.localScale;
		lightOriginalIntensity = pointLight.GetComponent<Light>().intensity;
		lightOriginalRange = pointLight.GetComponent<Light>().range;
	}
	
	void Update () {


			
		if(gameObject.transform.localScale.magnitude > originalSize.magnitude){
				gameObject.transform.localScale -= fadeOutSpeedVec;
		}

		if(pointLight.GetComponent<Light>().range > lightOriginalRange){
			pointLight.GetComponent<Light>().range -= fadeOutSpeedVec.magnitude / 2;
		}

		
		if(pointLight.GetComponent<Light>().intensity > lightOriginalIntensity){
			pointLight.GetComponent<Light>().intensity -= fadeOutSpeedVec.magnitude / 100;
		}

	}


	void beatMe(){
		Vector3 tempScale = originalSize * myParameters.enlargeRate;
		gameObject.transform.localScale = tempScale;
		float tempIensity = lightOriginalIntensity * myParameters.lightAmplifyRate;
		float tempRange = lightOriginalRange * myParameters.lightAmplifyRate/3;
		pointLight.GetComponent<Light>().intensity = tempIensity;
		pointLight.GetComponent<Light>().range = tempRange;
	}

}