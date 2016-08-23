using UnityEngine;
using System.Collections;

public class FadeInC2BGSound : MonoBehaviour {


	public float targetVol = 1.0f;
	public float fadeInRate = 0.04f;

	float myVol;
	bool fadeInComplete = false;

	// Use this for initialization
	void Start () {
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
