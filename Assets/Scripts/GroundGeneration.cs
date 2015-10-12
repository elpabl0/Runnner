using UnityEngine;
using System.Collections;

public class GroundGeneration : MonoBehaviour {

	public GameObject groundCube;
	public int buildAhead;

	private int playerPosition;

	// Use this for initialization
	void Start () {
		LayPath ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LayPath (){
		for (int i = 0; i < buildAhead; i++) {
			Instantiate (groundCube, new Vector3 (0, 0, playerPosition + i), Quaternion.identity);
		}
	}
}
