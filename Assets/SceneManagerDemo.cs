using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SceneManagerDemo : MonoBehaviour {

    public GameObject FadeBlackness;

    [YarnCommand("FadeSceneOut")]
    public void FadeOut(string Fade)
    {
        Debug.Log("called " + Fade);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
