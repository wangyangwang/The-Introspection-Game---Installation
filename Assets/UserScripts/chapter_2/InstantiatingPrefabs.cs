using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiatingPrefabs : MonoBehaviour {


	Object[] realisticPrefabs;
	Object[] halfRealPrefabs;
	Object[] abstractPrefabs;
	public List<GameObject> allLoaded;
	public List<Vector3> rotateSpeed;


	void Start () {
		allLoaded = new List<GameObject>();
		rotateSpeed = new List<Vector3>();
		realisticPrefabs = Resources.LoadAll("chaptertwo/realistic",typeof(GameObject));
		halfRealPrefabs = Resources.LoadAll("chaptertwo/halfReal",typeof(GameObject));

		for(int i=0;i<myParameters.realWorldObjectNumber;i++){
			Vector3 randomPos = new Vector3(Random.Range(-myParameters.xRange,myParameters.xRange), 
			                                Random.Range(myParameters.realWorldObjectStartHeight,myParameters.realWorldOBjectEndHeight), 
			                                Random.Range(-myParameters.zRange,myParameters.zRange));
			GameObject newObj = (GameObject)Instantiate(realisticPrefabs[Random.Range(0,realisticPrefabs.Length-1)], randomPos , Random.rotation);
			newObj.transform.parent = GameObject.Find("realWorldObjects").transform;

			allLoaded.Add(newObj);
			rotateSpeed.Add(new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f)));
		}

		for(int i=0;i<myParameters.halfRealObjectNumber;i++){
			Vector3 randomPos = new Vector3(Random.Range(-myParameters.xRange,myParameters.xRange), 
			                                Random.Range(myParameters.halfRealObjectStartHeight,myParameters.halfRealObjectEndHeight), 
			                                Random.Range(-myParameters.zRange,myParameters.zRange));
			GameObject newObj = (GameObject)Instantiate(halfRealPrefabs[Random.Range(0,halfRealPrefabs.Length-1)], randomPos , Random.rotation);
			newObj.transform.parent = GameObject.Find("halfReal").transform;
			newObj.AddComponent("TheAmazingWireframeGenerator");
			allLoaded.Add(newObj);
			rotateSpeed.Add(new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f)));
		}

		for(int i=0;i<myParameters.abstractObjectNumber;i++){

			Vector3 randomPos = new Vector3(Random.Range(-myParameters.xRange,myParameters.xRange),
			                                Random.Range(myParameters.abstractObjectStartHeight,myParameters.abstractObjectEndHeight),
			                                Random.Range(-myParameters.zRange,myParameters.zRange));
			GameObject aCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			aCube.transform.position = randomPos;
			float randomScale = Random.Range(myParameters.abstractObjectRange.x,myParameters.abstractObjectRange.y);
			Vector3 cubeScale = new Vector3(randomScale,randomScale,randomScale);
			aCube.transform.localScale = cubeScale;
			aCube.transform.parent = GameObject.Find("abstractObjects").transform;
			aCube.AddComponent<MeshCollider>();
			allLoaded.Add(aCube);
			rotateSpeed.Add(new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f)));
		}

		allLoaded.Add(GameObject.Find("LaboratoryGallery_prefab"));
		rotateSpeed.Add(new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f)));
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<allLoaded.Count-1;i++){
			allLoaded[i].transform.RotateAround(allLoaded[i].transform.position,rotateSpeed[i],Time.deltaTime * myParameters.generatedObjectRotatationSpeed);
		}
	}


	void instantiating(){
	}
}
