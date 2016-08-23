using UnityEngine;
using System.Collections;

public class mapVolToParticleAmount : MonoBehaviour {


	float targetVol, currentVol;
	public float catchUpRate = 0.01f;
	// Use this for initialization
	void Start () {
		currentVol = gameObject.GetComponent<AudioSource>().volume;
	}
	
	// Update is called once per frame
	void Update () {

		if(GameObject.Find("Particle System").GetComponent<ParticleSystem>().emissionRate < Emit.emissionRateTarget){
			targetVol = myMethods.Map(GameObject.Find("Particle System").GetComponent<ParticleSystem>().emissionRate,0,Emit.emissionRateTarget,0,1);
			if(targetVol > currentVol){
				currentVol += catchUpRate * Time.deltaTime;
				gameObject.GetComponent<AudioSource>().volume = currentVol;
			}
		}
	}
	

}
