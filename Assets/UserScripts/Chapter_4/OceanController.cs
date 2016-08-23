using UnityEngine;
using System.Collections;

public class OceanController: MonoBehaviour {

	GameObject[] oceanPlanes;

	public float wavesHeight;
	public float wavesSpeed;
	public float wavesMode;

	
	public float wavesHeightIncreaseRate = 0.001f;
	public float wavesSpeedINcreaseRate = 0.001f;

	void Start () {
		oceanPlanes = GameObject.FindGameObjectsWithTag("oceanPlane");
		for(int i=0; i<oceanPlanes.Length; i++){
			oceanPlanes[i].GetComponent<WC15PRO>().wavesHeight = wavesHeight;
			oceanPlanes[i].GetComponent<WC15PRO>().wavesMode = wavesMode;
			oceanPlanes[i].GetComponent<WC15PRO>().speed = wavesSpeed;
		}
	}

	void FixedUpdate(){
		if(BreathDataProcesser.isInhaling){
			for(int i=0; i<oceanPlanes.Length; i++){
				oceanPlanes[i].GetComponent<WC15PRO>().wavesHeight += wavesHeightIncreaseRate;
				oceanPlanes[i].GetComponent<WC15PRO>().speed += wavesSpeedINcreaseRate;

			}
		}else{
			for(int i=0; i<oceanPlanes.Length; i++){
				if(oceanPlanes[i].GetComponent<WC15PRO>().wavesHeight > wavesHeight){
					oceanPlanes[i].GetComponent<WC15PRO>().wavesHeight -= wavesHeightIncreaseRate;
				}
				if(oceanPlanes[i].GetComponent<WC15PRO>().speed > wavesSpeed){
					oceanPlanes[i].GetComponent<WC15PRO>().speed -= wavesSpeedINcreaseRate;
				}
			}
		}

	}
	

}
