using UnityEngine;
using System.Collections;

public class rotateMeAround : MonoBehaviour {

	public float rotate_rate = 0.1f;
	public bool random_direction = true;
	Vector3 direction;

	// Use this for initialization
	void Start () {
		direction = new Vector3(Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1));
	}
	
	// Update is called once per frame
	void Update () {
		if(random_direction){
			gameObject.transform.RotateAround(gameObject.transform.position,direction,Time.deltaTime * rotate_rate);

		}else{
			gameObject.transform.RotateAround(gameObject.transform.position,Vector3.up,Time.deltaTime * rotate_rate);

		}
	}
}
