using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float startSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = -transform.forward * startSpeed;
		startSpeed = startSpeed + 0.01f;
	}

	public void SetSpeed (float gameSpeed)
	{
		startSpeed = startSpeed + gameSpeed;
	}
}
