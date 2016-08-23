using UnityEngine;
using System.Collections;

public class ToChapterFive : MonoBehaviour {


	float thisChapterStartTime;

	// Use this for initialization
	void Start () {
		thisChapterStartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - thisChapterStartTime > myParameters.chapterFourLastingTime){
			Application.LoadLevel(4);
		}
	}
}
