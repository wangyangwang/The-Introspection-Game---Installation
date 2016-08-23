using UnityEngine;
using System.Collections;

public class mapOnSurfaceFoamWithDeepBreath : MonoBehaviour {

	void OnEnable(){
		BreathDataProcesser.deepBreathHappened += temporarilyIntensifyFoam;
	}

	void OnDisable(){
		BreathDataProcesser.deepBreathHappened -= temporarilyIntensifyFoam;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void temporarilyIntensifyFoam(){
		gameObject.GetComponent<ParticleSystem>().Emit(2000);
	}
}
