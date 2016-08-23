using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PulseDataProcessor : MonoBehaviour {
	
	public delegate void del();
	public static event del heartJustBeat;

	public List<float> beatTimeStamp;
	public List<float> BPMData;

	private float temp;
	float BPM;

	private float waitTime;

	// Use this for initialization
	void Start () {
		beatTimeStamp = new List<float>();
		BPMData = new List<float>();

		temp = 0;
		BPM = 0;

		waitTime = 10.0f;
	}

	public float getBPM(){
			return BPM;
	}
	
	void Update () {
		if (Time.time > waitTime) {
			getUniqueBeat ();	
		}

		if(beatTimeStamp.Count>21){
			beatTimeStamp.RemoveAt(0);
			calcBPM ();
		}

		if (BPMData.Count > 500) {
			BPMData.RemoveAt(0);		
		}
	}

	private void getUniqueBeat(){
		float rawData = sensorInput.getSingleton().rawHeartBeatValue;			
		if (temp < 60 ) {
			if(rawData > 600){
				beatTimeStamp.Add (Time.time);
				if(heartJustBeat!=null){
					heartJustBeat();
				}

			}
		}
		temp = rawData; 
	}

	private void calcBPM(){
		float beatDuration = (beatTimeStamp [beatTimeStamp.Count - 1] - beatTimeStamp [0]) / (beatTimeStamp.Count - 1);
		BPM = 60.0f/beatDuration;
		BPMData.Add (BPM);
//		SensorProcessingMethods.drawCurves(BPMData);
	}



}
