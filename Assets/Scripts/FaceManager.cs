using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour {


 public ExampleVariableStorage variableStorage; //Link this later without public variabling it.
    //variableStorage.GetValue("$variable_name").AsBool


	public GameObject Secretary;
	public GameObject Martin;
	public GameObject Youssaf;	
	public GameObject Stein;
	
	// Update is called once per frame
	void Update () {
		if(variableStorage.GetValue("$MartinFace").AsBool == true){
			Martin.SetActive(true);
		}else{
			Martin.SetActive(false);
		}

		if(variableStorage.GetValue("$SteinFace").AsBool == true){
			Stein.SetActive(true);
		}else{
			Stein.SetActive(false);
		}

		if(variableStorage.GetValue("$YoussafFace").AsBool == true){
			Youssaf.SetActive(true);
		}else{
			Youssaf.SetActive(false);
		}

		if(variableStorage.GetValue("$SecretaryFace").AsBool == true){
			Secretary.SetActive(true);
		}else{
			Secretary.SetActive(false);
		}
	}
}
