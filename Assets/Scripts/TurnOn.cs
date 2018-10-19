using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class TurnOn : MonoBehaviour {
    public GameObject[] behaviors;

    [YarnCommand("turnOnn")]
    public void SetGameObjectOn()
    {
        foreach(GameObject mono in behaviors)
        {
            mono.SetActive(true);
        }
    }
    [YarnCommand("turnOff")]
    public void SetGameObjectOff()
    {
        foreach (GameObject mono in behaviors)
        {
            mono.SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
