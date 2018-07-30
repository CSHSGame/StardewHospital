using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableReview : MonoBehaviour {

public GameObject review;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1) )
			{
				if (review.activeSelf){
					review.SetActive(false);
				} else{
					review.SetActive(true);
				}
			}
	}
}
