using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	
	public PlayerController playerController;
	public BlockGenerator blockGenerator;

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Collectable")) {
			playerController.LifeUpdate (-10 * blockGenerator.gameSpeed);
		}
		Destroy (other.gameObject);

	}


}