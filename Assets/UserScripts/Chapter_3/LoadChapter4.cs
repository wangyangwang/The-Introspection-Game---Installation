using UnityEngine;
using System.Collections;

public class LoadChapter4 : MonoBehaviour {



	float timeStamp;
	bool timeStampRecorded = false;


	//celebrate particle system
	public GameObject celebreatePS;
	public float PSfadeOutTime;
	public float PSFadeOutRate;
	bool fadeOutStart;


	// Use this for initialization
	void Start () {
		PSfadeOutTime = myParameters.waitingTimeTillSwtich / 2 ;
		PSFadeOutRate = (1-0)/PSfadeOutTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(!FogControl.inFog && !timeStampRecorded){
			Debug.Log("out for area, start count down...");
			timeStampRecorded = true;
			timeStamp = Time.time;
			celebreatePS.GetComponent<ParticleSystem>().emissionRate = 0;
		}

		if(timeStampRecorded && Time.time - timeStamp > myParameters.waitingTimeTillSwtich){
			Debug.Log("loading level 3");
			Application.LoadLevel(3);
		}

	}
}
