using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SceneManagerDemo : MonoBehaviour {

 
    public FadeObjectInOut fadeObject;

    [YarnCommand("FadeSceneOut")]
    public void FadeOut(string Fade)
    {
        Debug.Log("called " + Fade);
        fadeObject.FadeIn();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
