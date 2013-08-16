using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public AudioClip audioDead;
	public GameObject explosion;
	public Texture[] animated;
	public GUIText texto;
	public float speed = 15;
	private int counter = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		texto.text = "Score: " + counter/20;
		//Debug.Log(Screen.width + " - " + Screen.height);
		renderer.material.mainTexture = animated[0];
		if(Input.GetKey(KeyCode.W)) {
			renderer.material.mainTexture = animated[1];
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)) {
			renderer.material.mainTexture = animated[2];
			transform.position += transform.forward * -speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.D)) {
			//renderer.material.mainTexture = animated[0];
			transform.position += transform.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)) {
			//renderer.material.mainTexture = animated[0];
			transform.position += transform.right * -speed * Time.deltaTime;
		}
		
		//Touch
		Touch touch;
		for (var i = 0; i < Input.touchCount; ++i) {
			touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began) {
				Debug.Log ("X:" + touch.position.x + " Y:" + touch.position.y);
				if (touch.position.y < transform.position.y)
					renderer.material.mainTexture = animated[1];
				if (touch.position.y > transform.position.y)
					renderer.material.mainTexture = animated[2];
				transform.position = touch.position;				
			}
		}
				
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		float maxX = 30;
		float maxY = 17;
		if (transform.position.x <= -maxX) transform.position = new Vector3(-maxX,y,z);
		if (transform.position.x >= maxX) transform.position = new Vector3(maxX,y,z);
		if (transform.position.y <= -maxY) transform.position = new Vector3(x,-maxY,z);
		if (transform.position.y >= maxY) transform.position = new Vector3(x,maxY,z);
		
		// Acelerometro
		/*
		Vector3 dir = Vector3.zero;	
		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;
		// clamp acceleration vector to the unit sphere
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
	
		// Make it move 10 meters per second instead of 10 meters per frame...
		dir *= Time.deltaTime;
	
		// Move object
		p.transform.Translate (dir * speed);
		*/
			
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "enemy") {
			Camera.main.GetComponent<cameraShake>().Shake();
			Instantiate(explosion, transform.position, transform.rotation);
			audio.PlayOneShot(audioDead);
			gameObject.SetActive(false);
			//Destroy(gameObject);
		}
	}

}
