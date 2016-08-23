using UnityEngine;
using System.Collections;

public class ShakeMe : MonoBehaviour {


	public float intensity = 0;
	bool isShake = true;


	void OnEnable(){
		Emit.c3MissionComplished += turnOffShake;
	}

	void OnDisable(){
		Emit.c3MissionComplished -= turnOffShake;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(isShake){
			intensity = myMethods.Map(GameObject.Find("Particle System").GetComponent<ParticleSystem>().emissionRate,0.0f,Emit.emissionRateTarget,0.0f,0.2f);
			Vector3 offset = new Vector3(Random.Range(-intensity,intensity),Random.Range(-intensity,intensity),Random.Range(-intensity,intensity));
			gameObject.transform.position += offset;
		}

	}

	void turnOffShake(){
		isShake = false;
		gameObject.transform.position = new Vector3(0,0,0);
	}
}
