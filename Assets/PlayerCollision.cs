using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

	public Text uiCoinsText;
	public Text uiLivesText;
	private int coins = 0;
	private int lives = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D hit)
	{

		if (hit.gameObject.tag == "Coin") {
			Destroy (hit.gameObject);
			coins++;
			updateCoinsText ();
		} else if (hit.gameObject.tag == "EndLevel") {
			Application.LoadLevel ("Scene2");
		} else if (hit.gameObject.tag == "TrapLevel1") {
			lifeLost ();
		} else if (hit.gameObject.tag == "Water") {
			lifeLost ();
		} else if (hit.gameObject.tag == "EndGameObject") {
			Application.Quit ();
		} else if (hit.gameObject.tag == "StartGameObject") {
			Application.LoadLevel ("Scene1");
		} else if (hit.gameObject.tag == "Level1Portal1") {
			this.transform.position = new Vector2 (230, 50);
		} else if (hit.gameObject.tag == "Level1Portal2") {
			this.transform.position = new Vector2 (114, 32);
		} else if (hit.gameObject.tag == "ReturnToMenu") {
			Application.LoadLevel ("MenuScene");
		} else if (hit.gameObject.tag == "Level2Portal1") {
			this.transform.position = new Vector2 (-14, 31);
		} else if (hit.gameObject.tag == "Level2Portal2") {
			this.transform.position = new Vector2 (117, 42);
		} else if (hit.gameObject.tag == "Star") {
			Destroy (hit.gameObject);
			coins += 5;
			updateCoinsText ();
		} else if (hit.gameObject.tag == "Level2Floor") {
			lifeLost ();
			resetLevel ();
		} else if (hit.gameObject.tag == "Level2Finish") {
			Application.LoadLevel ("MenuScene");
		} else if (hit.gameObject.tag == "MenuSceneFloor") {
			Application.LoadLevel ("MenuScene");
		} else if (hit.gameObject.tag == "Life") {
			Destroy (hit.gameObject);
			this.lives++;
			updateLivesText ();
		} else if (hit.gameObject.tag == "MenuSceneStar") {
			Destroy (hit.gameObject);
			coins += 5;
			this.uiCoinsText.text = "Coins: " + coins.ToString() + "/20";
		}
	}

	void updateLivesText(){
		this.uiLivesText.text = lives.ToString();
	}

	void updateCoinsText(){
		this.uiCoinsText.text = coins.ToString() + "/20";
	}

	void lifeLost(){
		this.lives--;
		updateLivesText ();
		if (lives < 0) {
			Application.LoadLevel ("MenuScene");
		}
		resetLevel ();
	}

	void resetLevel(){
		if (Application.loadedLevelName == "Scene1") {
			this.transform.position = new Vector2 (-9, 1);
		} else if (Application.loadedLevelName == "Scene2") {
			this.transform.position = new Vector2 (-14, 21);
		}
	}

}
