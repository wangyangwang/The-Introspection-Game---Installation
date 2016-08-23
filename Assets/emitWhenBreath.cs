using UnityEngine;
using System.Collections;

public class emitWhenBreath : MonoBehaviour {

	void OnEnable(){
		BreathDataProcesser.deepBreathHappened += emitFoam;
	}

	void OnDisable(){
		BreathDataProcesser.deepBreathHappened -= emitFoam;
	}

	public int normalBreathFoamN = 10;
	public int deepbreathFoamN = 1000;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(BreathDataProcesser.isInhaling){
			gameObject.GetComponent<ParticleSystem>().Emit(normalBreathFoamN);
		}
	}

	void emitFoam(){
		gameObject.GetComponent<ParticleSystem>().Emit(deepbreathFoamN);
	}

}
