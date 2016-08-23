using UnityEngine;
using System.Collections;

public class FadeOutColorAndKillMe : MonoBehaviour {
	
	float fadeRate = 0.005f;
	public GameObject finalParticleSyste;
	bool particleSystemChanged = false;
	
	void OnEnable(){
		Emit.c3MissionComplished += KickOffFading;
	}

	void OnDisable(){
		Emit.c3MissionComplished -= KickOffFading;
	}

	// Use this for initialization
	void Start () {
		finalParticleSyste = GameObject.Find("Particle System Celebrate");
		finalParticleSyste.GetComponent<ParticleSystem>().emissionRate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.renderer.material.color.a < 0.1f){
			gameObject.SetActive(false);
			if(!particleSystemChanged){
				finalParticleSyste.GetComponent<ParticleSystem>().emissionRate = 200;
				particleSystemChanged =true;
			}
		}
	}

	void KickOffFading(){
		StartCoroutine(fadeOutColor());
	}

	IEnumerator fadeOutColor(){
		while(gameObject.renderer.material.color.a > 0){
			Color temp = gameObject.renderer.material.color;
			temp.a -= fadeRate;
			gameObject.renderer.material.color = temp;
			yield return new WaitForSeconds(0.01f);
		}
	}
}
