using UnityEngine;
using System.Collections;

public class Emit : MonoBehaviour {

	public delegate void del();
	public static event del c3MissionComplished;

	int counter;
	public bool missionComplished = false;
	ParticleSystem ps;

	public float regularBreathEmissionRatePlus = 0.003f;
	public float deepBreathemissionRatePlus = 0.34f;
	public static float emissionRateTarget = 200.0f;

	int emissionRate = 0;

	void OnEnable(){
		BreathDataProcesser.deepBreathHappened += EmitAlot;
	}

	void OnDisable(){
		BreathDataProcesser.deepBreathHappened -= EmitAlot;
	}

	// Use this for initialization
	void Start () {
		ps = gameObject.GetComponent<ParticleSystem>();
		ps.emissionRate = emissionRate;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if(counter % 60 == 0){
			if(BreathDataProcesser.isInhaling){
				ps.emissionRate += emissionRateTarget * regularBreathEmissionRatePlus;
			}
		}
	}

	void EmitAlot(){
		if(Time.timeSinceLevelLoad > 10){
			Debug.Log("hha");
			ps.emissionRate += emissionRateTarget * deepBreathemissionRatePlus;

			if(ps.emissionRate >= emissionRateTarget && missionComplished == false){
				missionComplished = true;
				if(c3MissionComplished != null){
					c3MissionComplished();
				}
			}

		}

		Debug.Log("emission rate target: " +  emissionRateTarget + " | we have : " + ps.emissionRate);
	}

}