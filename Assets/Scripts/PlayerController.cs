using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public BlockGenerator blockGenerator;
	public float speed;
	public float xMin, xMax, yMin, yMax;
	public Text scoreText;
	public Text lifeText;
	public Text loseText;
	private Vector3 oldPosition;
	private float score;
	private float life;

	void Start() {
		speed = 5;
		oldPosition = transform.position;
		score = 0;
		life = 1000;
		SetScoreText ();
	}

	void FixedUpdate() {
		if (!Input.anyKey) {
			transform.position = Vector3.MoveTowards(transform.position, oldPosition, speed * Time.deltaTime);
		}
		Vector3 v3 = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
		transform.Translate(speed * v3.normalized * Time.deltaTime);    
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, xMin, xMax),
		Mathf.Clamp (transform.position.y, yMin, yMax),
		0.0f
		);
	}

//	void FixedUpdate() {
//		Vector3 v3 = new Vector3(Input.acceleration.x, Input.acceleration.y, 0.0f);
//			transform.Translate(speed * v3.normalized * Time.deltaTime);    
//			transform.position = new Vector3 (
//				Mathf.Clamp (transform.position.x, xMin, xMax),
//			Mathf.Clamp (transform.position.y, yMin, yMax),
//			0.0f
//			);
//		}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Collectable")) {
			Destroy (other.gameObject);
			score = score +  (10 * blockGenerator.gameSpeed);
			SetScoreText ();
		}
		if (other.gameObject.CompareTag ("Bad Block")) {
			Destroy (other.gameObject);
			LifeUpdate (-10 * blockGenerator.gameSpeed);
		}
	}
	
	public void LifeUpdate (float lifeMod)
	{
		Debug.Log (lifeMod);
		life = life + lifeMod;
		SetScoreText ();
	}

	void SetScoreText ()
		{
			score = Mathf.Round (score);
			life = Mathf.Round (life);
			scoreText.text = "Score: " + score.ToString ();
			lifeText.text = "Life: " + life.ToString ();
			if (life <= 0)
			{
				loseText.text = "Game Over!";
				Destroy (gameObject);
			}
		}
}