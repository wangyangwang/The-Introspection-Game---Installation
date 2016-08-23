using UnityEngine;
using System.Collections;

public class playHeartBeatSound : MonoBehaviour {


	void OnEnable(){
		PulseDataProcessor.heartJustBeat += playSound;
	}

	void OnDisable(){
		PulseDataProcessor.heartJustBeat -= playSound;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playSound(){
		gameObject.GetComponent<AudioSource>().Play();
	}

}
