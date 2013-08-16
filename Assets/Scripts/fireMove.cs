using UnityEngine;
using System.Collections;

public class fireMove : MonoBehaviour {

	public Texture[] animated;
	public float speed;
	double currentTime = 0;
	int counter = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += 0.2;
		if(currentTime>= 1) {
			currentTime = 0;
			counter++;
		}
		if(counter>=3) counter=0;
		renderer.material.mainTexture = animated[counter];
		transform.position += transform.right * -speed * Time.deltaTime;
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "border") {
			Destroy(gameObject);
		}
	}
}
