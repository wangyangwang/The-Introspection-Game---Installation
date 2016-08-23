using UnityEngine;
using System.Collections;

public class C2FogController : MonoBehaviour {

	public GameObject ovrController;
	public int fadeOutTimeSeconds = 30;
	public float fogFadeOutRate;


	public GameObject soundObject;
	public float soundFadeRate;

	// Use this for initialization
	void Start () {
		fogFadeOutRate = (myParameters.c2StartFogDensity - myParameters.c2NormalFogDensity) / fadeOutTimeSeconds;
		soundFadeRate = (0-0.3f) / fadeOutTimeSeconds;
	}
	
	// Update is called once per frame
	void Update () {

		if(ovrController.transform.position.y < myParameters.startFadeOutHeight){
			Debug.LogWarning("Start Fade Out Sound and Densify Fog");
			float temp = RenderSettings.fogDensity;
			if(temp <= myParameters.c2StartFogDensity) 
			{
				temp += fogFadeOutRate * Time.deltaTime;
				RenderSettings.fogDensity = temp;
			}

			float sound_temp = soundObject.GetComponent<AudioSource>().volume;
			if(sound_temp >= 0 && soundObject.GetComponent<AudioSource>().isPlaying) 
			{
				sound_temp += soundFadeRate * Time.deltaTime;
				soundObject.GetComponent<AudioSource>().volume = sound_temp;
			}
		}

	}
}
