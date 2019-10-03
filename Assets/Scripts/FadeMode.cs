using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class FadeMode : MonoBehaviour {

    public Color On;
    public Color Off;
    public Text msgText;
    public static bool isOn = false;
    [YarnCommand("Fade")]
    public void FadeOn()
    {
        GetComponent<Image>().color = On;
        isOn = true;
    }
    [YarnCommand("DeFade")]
    public void FadeWaitCommand()
    {
        StartCoroutine(fadeWait());
       // GetComponent<Image>().color = Off;
    }
    public void FadeOff()
    {
        GetComponent<Image>().color = Off;
        isOn = false;
    }
    private IEnumerator fadeWait()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Image>().color = Off;
        isOn = false;

        yield return null;
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
