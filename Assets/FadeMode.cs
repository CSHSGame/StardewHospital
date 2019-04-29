using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class FadeMode : MonoBehaviour {

    public Color On;
    public Color Off;
    [YarnCommand("Fade")]
    public void FadeOn()
    {
        GetComponent<Image>().color = On;
    }
    [YarnCommand("DeFade")]
    public void FadeOFF()
    {
        StartCoroutine(fadeWait());
       // GetComponent<Image>().color = Off;
    }
    public IEnumerator fadeWait()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Image>().color = Off;

        yield return null;
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
