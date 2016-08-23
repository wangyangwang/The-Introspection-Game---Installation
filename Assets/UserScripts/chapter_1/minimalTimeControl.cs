using UnityEngine;
using System.Collections;

public class minimalTimeControl : MonoBehaviour {

	public static bool c1ReadyToSwtich = false;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Time.time > myParameters.c1MinimalStayingTime){
			c1ReadyToSwtich = true;
		}
	}
}
