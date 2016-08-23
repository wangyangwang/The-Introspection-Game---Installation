using UnityEngine;
using System.Collections;

public class triggerSoundAfterBreath : MonoBehaviour {


	public GameObject afterBreathSound;

	void OnEnable(){
		BreathDataProcesser.deepBreathHappened += playLightSound;
	}

	void OnDisable(){
		BreathDataProcesser.deepBreathHappened -= playLightSound;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playLightSound(){
		afterBreathSound.GetComponent<AudioSource>().Play();
		Debug.Log("Deep Breath Detected");
	}

}
