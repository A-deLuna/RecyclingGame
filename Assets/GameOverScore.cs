using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = "Score: " + ScoreManager.score;
	}
	public void click() {
		ScoreManager.score = 0;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MainScene");
	}
}
