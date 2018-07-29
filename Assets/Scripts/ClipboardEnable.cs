using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardEnable : MonoBehaviour {

public GameObject clipboard;
	
	void OnMouseDown()
	{
		if (clipboard.activeSelf){
			clipboard.SetActive(false);
		}else{
			clipboard.SetActive(true);
		}
	}
}
