using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;

public class triggerText : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player Sprite"){
			print("check");
			other.gameObject.transform.parent.GetComponent<PlayerCharacter>().CheckForNearbyNPC();//print ("Player");
		}
	}
}
