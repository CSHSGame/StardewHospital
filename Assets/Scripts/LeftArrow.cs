using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrow : MonoBehaviour {

public GameObject rightArrow;

	// Use this for initialization
	void Start(){
		//rightArrow.GetComponent<Review>().pageNumber;
	}

	void OnMouseDown()
		{
			print("clickedLeft");
			rightArrow.GetComponent<FlipRight>().pageNumber--;			
		}
	}
