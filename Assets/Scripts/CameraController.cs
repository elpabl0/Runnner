using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	
	public float xAxis;
	public float yAxis;
	public float zAxis;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//this.transform.position = new Vector3 (target.transform.position.x + xAxis, target.transform.position.y + yAxis, target.transform.position.z + zAxis);
		transform.LookAt(target);
	}
}
