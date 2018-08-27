using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSwitch : MonoBehaviour {

	public GameObject clientsPage;
	public GameObject toDoPage;
	public GameObject thisPage;
	public GameObject otherPage;
	public GameObject martinCheck;
	public GameObject youssafCheck;
	public GameObject steinCheck;

	public bool thisIsTodo;

	public bool spokeMartin;
	public bool spokeYoussaf;
	public bool spokeStein;


	void Start(){
		if (thisIsTodo == true) {
			thisPage = toDoPage;
			otherPage = clientsPage;
		} else {
			thisPage = clientsPage;
			otherPage = toDoPage;
		}
	}

	void OnMouseDown()
	{
		otherPage.SetActive(true);
		thisPage.SetActive(false);
	}

	void OnEnable(){
		if (spokeMartin == true) {
			martinCheck.SetActive(true);
		} else {
			martinCheck.SetActive (false);
		}

		if (spokeYoussaf == true) {
			youssafCheck.SetActive (true);
		} else {
			youssafCheck.SetActive (false);
		}

		if (spokeStein == true) {
			steinCheck.SetActive (true);
		} else {
			steinCheck.SetActive (false);
		}
	}
}
