using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("x", 3, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
		//iTween.MoveBy(gameObject, iTween.Hash("Y", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
}

