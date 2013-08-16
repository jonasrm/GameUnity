using UnityEngine;
using System.Collections;

public class parallax : MonoBehaviour {

	public float speed = 1f;
	private float counter = 0f;
	
	// Update is called once per frame
	void Update () {
		counter += speed * Time.deltaTime;
		if(counter >= 1) counter = 0;
		Debug.Log(Time.deltaTime);
		renderer.material.mainTextureOffset = new Vector2(counter,0);
	}
}
