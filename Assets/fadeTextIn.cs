using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeTextIn : MonoBehaviour {

//	public float fadeInRate;
	public float fadeInTime = 3.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<Text>().color.a < 1){
			Color textC =  gameObject.GetComponent<Text>().color;
			textC.a += 0.3f * Time.deltaTime;
			gameObject.GetComponent<Text>().color = textC;
		}
	}
}
