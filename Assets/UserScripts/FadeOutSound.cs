using UnityEngine;
using System.Collections;

public class FadeOutSound : MonoBehaviour {


	public float fadeOutRate = 0.01f;
	public float targetVol = 0.0f;

	AudioSource myaudio;
	

	void OnEnable(){
		Emit.c3MissionComplished += kickOffFading;
	}
	
	void OnDisable(){
		Emit.c3MissionComplished -= kickOffFading;
	}


	// Use this for initialization
	void Start () {
		myaudio = gameObject.GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void kickOffFading(){
		myaudio.Stop();
		GameObject.Find("TongSound").GetComponent<AudioSource>().Play();
//		StartCoroutine(fadingOut());
	}

//	IEnumerator fadingOut(){
//		while(myaudio.volume > targetVol){
//			myaudio.volume -= fadeOutRate;
//			yield return new WaitForSeconds(0.01f);
//		}
//	}
}
