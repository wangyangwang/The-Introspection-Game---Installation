using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
	public float totalTimePassed;
	public float thisChapterPassed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		totalTimePassed = Time.time;
		thisChapterPassed = Time.timeSinceLevelLoad;
	}
}
