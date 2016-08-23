using UnityEngine;
using System.Collections;

public class randomScale : MonoBehaviour {

	public float random_range = 2.0f;
	float x,y,z;
	float x_noise_index, y_noise_index, z_noise_index;

	// Use this for initialization
	void Start () {
		x_noise_index = Random.Range(0.0f,0.1f);
		y_noise_index = Random.Range(0.0f,0.1f);
		z_noise_index = Random.Range(0.0f,0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		x_noise_index += 0.01f;
		y_noise_index += 0.01f;
		z_noise_index += 0.01f;
		Vector3 s = new Vector3(random_range * Mathf.PerlinNoise(x_noise_index,1), random_range * Mathf.PerlinNoise(y_noise_index,1), random_range * Mathf.PerlinNoise(z_noise_index,1));
		gameObject.transform.localScale = s;
	}
}
