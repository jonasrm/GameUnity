using UnityEngine;
using System.Collections;

public class generateEnemy : MonoBehaviour {
	
	public GameObject prefab;
	float y, x;
	int counter = 0;
	public bool spawn = true;
	public int spawnSpeed = 10;
	Quaternion originRotation;
	
	// Use this for initialization
	void Start () {
		y = Random.Range(-17,17);
		x = transform.position.x;
		originRotation = transform.rotation;
		Instantiate(prefab, new Vector3(x,y,0), originRotation);
	}
	
	// Update is called once per frame
	void Update () {
		if(spawn) {
			counter++;
			if(counter >= spawnSpeed) {
				counter = 0;
				y = Random.Range(-16,16);
				Instantiate(prefab, new Vector3(x,y,0), originRotation);
			}
		}
	}
	
}
