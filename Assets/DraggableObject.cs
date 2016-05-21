using UnityEngine;
using System.Collections;

public class DraggableObject : MonoBehaviour {
	public float speed = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame	
	void Update () {
		if (Input.GetMouseButton (0)) {
			float y = Input.GetAxis ("Mouse Y");
			float x = Input.GetAxis ("Mouse X");
			transform.Translate (new Vector3(x * speed, y * speed));
	
		}
	}



	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("Collision");
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Trigger");
		ScoreManager.score++;
		transform.position = new Vector3(0,0,0);
	}
}
