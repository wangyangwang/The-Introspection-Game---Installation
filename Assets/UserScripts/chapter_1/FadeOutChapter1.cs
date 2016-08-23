using UnityEngine;
using System.Collections;

public class FadeOutChapter1: MonoBehaviour {

	bool sceneEnding = false;
	float lightFadeRate = 0.9f;
	float coroutineGapTime = 0.02f;

	//Fog
	float fogDensity;
	float initFogDensity;
	float targetFogDensity = 0.8f;
//	public bool printOutDensityAndAlpha = false;
	public float fogFadeRate;
	public bool fogFadeFinished = false;

	//Skybox
	public GameObject hollowSphere;
	Color hollowSphereColor;
	Color initSphereColor;
	public float sphereFadeRate;
	float targetSphereAlpha = 1.0f;
	public bool skyboxFadeFinished = false;


	//Sound
	public GameObject cityAmbienceSoundObject;
	float soundInitVol = 0.5f;
	float cityAmbienceSoundVol;
	float soundTargetVol = 0.0f;
	public float soundFadeOutRate;
	public bool soundFadeFinished = false;

	//Scene transittion
	float silenceTime = 2.0f;
	float timeStamp;
	bool timeStampRecorded = false;

	public GameObject[] floors;

	void OnEnable(){
		BreathDataProcesser.deepBreathHappened += kickOffFade;
	}

	void OnDisable(){
		BreathDataProcesser.deepBreathHappened -= kickOffFade;
	}

	// Use this for initialization
	void Start () {
		cityAmbienceSoundVol = cityAmbienceSoundObject.GetComponent<AudioSource>().volume;
		fogDensity = RenderSettings.fogDensity;
		initFogDensity = fogDensity;
		hollowSphereColor = hollowSphere.renderer.material.color;
		initSphereColor = hollowSphereColor;
		fogFadeRate =   ( (targetFogDensity - fogDensity) / ( myParameters.c1FadeTime * myParameters.fogFadeRelativeSpeed )) / (1/coroutineGapTime);
		sphereFadeRate = ( (targetSphereAlpha - hollowSphereColor.a) / (myParameters.c1FadeTime * myParameters.sphereFadeRelativeSpeed))/(1/coroutineGapTime);
		soundFadeOutRate = ((soundTargetVol - soundInitVol)/(myParameters.c1FadeTime * myParameters.soundFadeRalativeSpeed))/(1/coroutineGapTime);


		//Massaive hack
//		fogFadeRate = 0.001f;
//		sphereFadeRate = 0.1f;
//		soundFadeOutRate = 0.1f;

	}
	
	// Update is called once per frame
	void Update () {
		if(!sceneEnding){
			if(BreathDataProcesser.isInhaling){
				fogDensity += fogFadeRate * lightFadeRate;
				RenderSettings.fogDensity = fogDensity;

				hollowSphereColor.a += sphereFadeRate * lightFadeRate;
				hollowSphere.renderer.material.color = hollowSphereColor;
			}else{
				if(fogDensity > initFogDensity){
					fogDensity -= fogFadeRate * lightFadeRate;
					RenderSettings.fogDensity = fogDensity;
				}
				if(hollowSphereColor.a  > initSphereColor.a){
					hollowSphereColor.a -= sphereFadeRate * lightFadeRate;
					hollowSphere.renderer.material.color = hollowSphereColor;
				}
			}
		}

//		if(printOutDensityAndAlpha)Debug.Log("Fog Density: "+ fogDensity+"Alpha: "+hollowSphereColor.a);


//		Debug.Log(cityAmbienceSound.GetComponent<AudioSource>().volume);


		if(sceneEnding){
			if(RenderSettings.fogDensity >= targetFogDensity)fogFadeFinished=true;
			if(cityAmbienceSoundObject.GetComponent<AudioSource>().volume <= soundTargetVol)soundFadeFinished=true;
			if(hollowSphere.renderer.material.color.a >= targetSphereAlpha)skyboxFadeFinished=true;
		}

		if(fogFadeFinished && soundFadeFinished && skyboxFadeFinished){

			if(!timeStampRecorded){
				timeStamp = Time.time;
				timeStampRecorded = true;
			}
			if(Time.time - timeStamp > silenceTime)Application.LoadLevel(1);
		}
	}

	void kickOffFade(){
		if(minimalTimeControl.c1ReadyToSwtich && !sceneEnding){
			StartCoroutine(finalFadeFog());
			StartCoroutine(finalFadeHollowSphere());
			StartCoroutine(fadeOutCitySound());
			sceneEnding = true;
		}else{
			Debug.LogWarning("Detected a deep breath, But minimal Staying Time hasn't been fulfilled.");
		}
	}


	IEnumerator fadeOutCitySound() {
		while(cityAmbienceSoundObject.GetComponent<AudioSource>().volume > soundTargetVol){
			cityAmbienceSoundVol = cityAmbienceSoundObject.GetComponent<AudioSource>().volume;
			cityAmbienceSoundVol += soundFadeOutRate;
			cityAmbienceSoundObject.GetComponent<AudioSource>().volume = cityAmbienceSoundVol;
			yield return new WaitForSeconds(coroutineGapTime);
		}
	}

	
	IEnumerator finalFadeFog() {
		while(fogDensity < targetFogDensity){
			fogDensity += fogFadeRate;
			RenderSettings.fogDensity = fogDensity;

//			if(!soundFadeStarted && fogDensity >= targetFogDensity/5){
//				deleteFloor();
//			}

			yield return new WaitForSeconds(coroutineGapTime);
		}
	}

	IEnumerator finalFadeHollowSphere() {
		while(hollowSphereColor.a < targetSphereAlpha){
			hollowSphereColor.a += sphereFadeRate;
			hollowSphere.renderer.material.color = hollowSphereColor;
			yield return new WaitForSeconds(coroutineGapTime);
		}
	}

	void deleteFloor(){
		for(int i=0;i<floors.Length;i++){
			floors[i].SetActive(false);
		}
	}



}
