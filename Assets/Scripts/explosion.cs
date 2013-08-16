using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
	
	public Texture2D[] animated;
	private float counter = 0f;
	private int index = 0;
		
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if(counter >= 0.05f) {
			index++;
			counter = 0;
		}
		if(index > 7) {
			Destroy(gameObject);
		} else {
			renderer.material.mainTexture = animated[index];
		}
	}
}
