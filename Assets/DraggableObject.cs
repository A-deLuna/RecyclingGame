	using UnityEngine;
using System.Collections;


public class DraggableObject : MonoBehaviour
{
	enum Color {
		BLUE,
		BROWN,
		GREEN,
		BLACK
	}
	public float speed = 0.1f;
    public float timeDiff = 1f;
    // Use this for initialization
    private bool touchEnabled = true;
    private float timeToEnable = 0.0f;
	public Sprite[] sprites;
	private Color tipo;
	private bool fingerDown= false;
	private AudioSource source;
	private int life=0;
	public AudioClip s1,s2;
	
	void Awake()
	{
		source=GetComponent<AudioSource>();
	}
    void Start()
    {
		GenerateNextObject ();
		//aud=this.GetComponent<AudioSource>();

    }

    // Update is called once per frame	
    void OnMouseDrag()
    {
        if (Input.GetMouseButton(0) && touchEnabled && fingerDown)
        {
            // Get movement of the finger since last frame
            // Move object across XY plane
            Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
            transform.position = new Vector3(pos.x, pos.y , 0);

        }
    }

	void OnMouseDown() {
		fingerDown = true;	
	}


    void Update()
    {
        if (timeToEnable < Time.time)
        {
            touchEnabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
    }
		
    void OnTriggerEnter2D(Collider2D other)
    {      
		Debug.Log ("other tag: " + other.gameObject.tag + " State: " + tipo);
		if (other.gameObject.tag == "Blue" && tipo == Color.BLUE)
        {           
        	correct();                     
        }
		else if (other.gameObject.tag == "Brown" && tipo == Color.BROWN)
        {
            correct();   
        }
		else if (other.gameObject.tag == "Green" && tipo == Color.GREEN)
		{
			correct ();
		} 
		else if (other.gameObject.tag == "Black" && tipo == Color.BLACK)
        {
            correct();
        }
		else incorrect ();
   		GenerateNextObject ();
		fingerDown = false;
    }

	void GenerateNextObject() {
		int next = Random.Range (0, 20);
		Debug.Log (next);
		GetComponent<SpriteRenderer> ().sprite = sprites [next];
		ResizeSprite ();
		SetState (next);
		ResetPosition ();
	}

	void SetState(int index) {
		Debug.Log(index/5);
		switch (index / 5) {
		case 0:
			tipo = Color.BLUE;
			break;
		case 1:
			tipo = Color.BROWN;
			break;
		case 2:
			tipo = Color.GREEN;
			break;
		case 3:
			tipo = Color.BLACK;
			break;
		}
	}
	void ResizeSprite() {
		transform.localScale = Vector3.one;

		float width = GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
		float height = GetComponent<SpriteRenderer> ().sprite.bounds.size.y;

		transform.localScale = new Vector2 (3f / width, 3f / height);
		GetComponent<BoxCollider2D> ().size = new Vector2 (width, height);
	}

	void ResetPosition() {
		transform.position = new Vector3(0, 0, 0);
		DisableTouch ();
	}

	void DisableTouch() {
		touchEnabled = false;
		timeToEnable = Time.time + timeDiff;
	}

    void correct()
    {
    	//aud.Play();
    	source.PlayOneShot(s1,1f);
		ScoreManager.score++;
    }

    void incorrect()
    {
    	life++;
    	source.PlayOneShot(s2,1f);
    	if(life==1)
    	Destroy(GameObject.FindWithTag("v3"));
    	if(life==2)
    	Destroy(GameObject.FindWithTag("v2"));
    	if(life==3)
    	Destroy(GameObject.FindWithTag("v1"));
		if(life==4)
		UnityEngine.SceneManagement.SceneManager.LoadScene ("EndGameScene");
    }
}
