using UnityEngine;
using System.Collections;

public class ThisSoundFadeIn : MonoBehaviour {


	public float fadeInSeconds = 3.0f;
	public float targetVol = 0.3f;
	float fadeInRate;
	public float startVol = 0.0f;
	
	float myVol;
	bool fadeInComplete = false;
	
	// Use this for initialization
	void Start () {
		fadeInRate = (targetVol-startVol) / fadeInSeconds;
		myVol = startVol;
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
