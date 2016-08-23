using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetLabRoomVisibility : MonoBehaviour {


	public GameObject[] allPartsOfLabGallery;

	// Use this for initialization
	void Start () {
//		if(allPartsOfLabGallery == null){
			allPartsOfLabGallery = GameObject.FindGameObjectsWithTag("LabRoom");
//		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject part in allPartsOfLabGallery){
			part.renderer.material.shader = Shader.Find("Transparent/Diffuse");
			Debug.Log("?");
			Color c = part.GetComponent<Renderer>().material.color;
			c.a = 0.5f;
			part.renderer.material.color = c;
		}
	}
}
