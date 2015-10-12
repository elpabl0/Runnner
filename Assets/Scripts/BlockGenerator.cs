using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {

	public GameObject collectable;
	public GameObject badBlock;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float gameSpeed;
	
	private GameObject newBlock;
	private Vector3 spawnValues;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		gameSpeed = gameSpeed + 0.01f;
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				float chance = Random.value;
				if (chance <= 0.1){
					Vector3 spawnPosition = new Vector3 (Random.Range(-1,2), Random.Range(-1,2), 50);
					Quaternion spawnRotation = Quaternion.identity;
					newBlock = Object.Instantiate (badBlock, spawnPosition, spawnRotation) as GameObject;
					newBlock.GetComponent<Mover>().SetSpeed(gameSpeed);
					yield return new WaitForSeconds (spawnWait);
				}
				else {
					Vector3 spawnPosition = new Vector3 (Random.Range(-1,2), Random.Range(-1,2), 50);
					Quaternion spawnRotation = Quaternion.identity;
					newBlock = Object.Instantiate (collectable, spawnPosition, spawnRotation) as GameObject;
					newBlock.GetComponent<Mover>().SetSpeed(gameSpeed);
					yield return new WaitForSeconds (spawnWait);
				}
			}
			yield return new WaitForSeconds (waveWait);
		}
	
	}
}
