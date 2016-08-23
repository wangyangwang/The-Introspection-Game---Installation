using UnityEngine;
using System.Collections;

public class playBigWave : MonoBehaviour {


	void OnEnable(){
		BreathDataProcesser.deepBreathHappened += playBigWaveSound;
	}

	void OnDisable(){
		BreathDataProcesser.deepBreathHappened -= playBigWaveSound;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void playBigWaveSound(){
		gameObject.GetComponent<AudioSource>().Play();
	}

}
