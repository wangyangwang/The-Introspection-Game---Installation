using UnityEngine;
using System.Collections;

public class FadeInSound : MonoBehaviour {

	float targetVol;
	float fadeInRate;

	float myVol;
	bool fadeInComplete = false;

	// Use this for initialization
	void Start () {
		fadeInRate = myParameters.cityAmbienceSoundFadeInRate;
		targetVol = myParameters.cityAmbienceTargetVol;
		myVol = 0;
		gameObject.GetComponent<AudioSource>().volume = myVol;
	}
	
	// Update is called once per frame
	void Update () {

		if(!fadeInComplete){
			myVol += fadeInRate * Time.deltaTime;
			gameObject.GetComponent<AudioSource>().volume = myVol;
			if(myVol >= targetVol){
				fadeInComplete = true;
			}
		}
	
	}
}
