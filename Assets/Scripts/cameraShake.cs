using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour {
	
	private Vector3 originPosition;
	private Quaternion originRotation;
	public float p_shake_decay;
	public float p_shake_intensity;
	private float shake_decay;
	private float shake_intensity;
	
	/*
	void OnGUI() {
		if(GUI.Button (new Rect(20,40,80,20), "Shake")){
			Shake();
		}
	}
	*/
	
	void Start() {
		originPosition = transform.position;
		originRotation = transform.rotation;
	}
	
	void Update() {
		if(shake_intensity > 0) {
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range( -shake_intensity, shake_intensity) * .2f,
				originRotation.y + Random.Range( -shake_intensity, shake_intensity) * .2f,
				originRotation.z + Random.Range( -shake_intensity, shake_intensity) * .2f,
				originRotation.w + Random.Range( -shake_intensity, shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		} else if (shake_intensity == 0) {
			shake_intensity = -1;
			transform.position = originPosition;
			transform.rotation = originRotation;
		}
	}
	
	public void Shake() {
		shake_intensity = p_shake_intensity;
		shake_decay = p_shake_decay;
	}
	
}
