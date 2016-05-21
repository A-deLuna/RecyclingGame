using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	// Use this for initialization
	public static int score;
	Text text;
	void Awake () {
		text = GetComponent<Text> ();
		score = 0;
	}

	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}
}
