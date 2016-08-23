using UnityEngine;
using System.Collections;

public class FadeInFinalSound : MonoBehaviour {


	public float fadeInRate = 0.1f;
	public float targetVol = 1.0f;
	public bool startFinalFadeOut = false;

	//final fade out
	public float fadeoutRate;
	public float fadeOutTime = 15.0f;


	void OnEnable(){
		Emit.c3MissionComplished += kickOffFadeIn;
	}
	
	void OnDisable(){
		Emit.c3MissionComplished -= kickOffFadeIn;
	}

	// Use this for initialization
	void Start () {
		fadeoutRate = (0-targetVol)/fadeOutTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(!FogControl.inFog){
			startFinalFadeOut = true;
		}
		
		if(startFinalFadeOut){
			if(gameObject.GetComponent<AudioSource>().volume>0) gameObject.GetComponent<AudioSource>().volume += fadeoutRate * Time.deltaTime;
		}
	}

	void kickOffFadeIn(){
		gameObject.GetComponent<AudioSource>().Play();
		if(gameObject.GetComponent<AudioSource>().volume < targetVol && !startFinalFadeOut){
			gameObject.GetComponent<AudioSource>().volume += Time.deltaTime * fadeInRate;
		}


	}
}
