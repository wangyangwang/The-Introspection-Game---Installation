using UnityEngine;
using System.Collections;

public class FadeInListenerVol : MonoBehaviour {


	public float fadeInPlus = 0.00003f;
	public float fadeInAcc = 0.0f;
	float vol;
	// Use this for initialization
	void Start () {
		vol = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(AudioListener.volume<1){

			fadeInAcc+= fadeInPlus * Time.deltaTime;
			vol += fadeInAcc;

		}

		AudioListener.volume  = vol;

	}
}
