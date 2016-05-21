using UnityEngine;
using System.Collections;

public class DraggableObject : MonoBehaviour {
	public float speed = 0.1f;
	public float timeDiff = 1f;
	// Use this for initialization
	private bool touchEnabled = true;
	private float timeToEnable = 0.0f;

	void Start () {
	
	}
	
	// Update is called once per frame	
	void OnMouseDrag () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && touchEnabled) {
			// Get movement of the finger since last frame
			// Move object across XY plane
			Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5));
			transform.position = new Vector3(pos.x, pos.y , 0);
		}
	}

	void Update() {
		if (timeToEnable < Time.time) {
			touchEnabled = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("Collision");
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Trigger");
		ScoreManager.score++;
		transform.position = new Vector3(0,0,0);
		touchEnabled = false;
		timeToEnable = Time.time + timeDiff;
	}
}
