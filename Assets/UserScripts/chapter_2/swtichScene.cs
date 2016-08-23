using UnityEngine;
using System.Collections;

public class swtichScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("OVRPlayerController").transform.position.y < myParameters.sceneCutHeight){
			Application.LoadLevel(2);
		}
	}
}
