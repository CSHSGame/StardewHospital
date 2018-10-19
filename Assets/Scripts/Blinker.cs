using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour {
    public float invisible = 0.1f;
    public float visible = 0.5f;
    public GameObject ToBlink;
	// Use this for initialization
	void Start () {
        StartCoroutine(blink());
	}
	public IEnumerator blink()
    {
        ToBlink.SetActive(false);
        yield return new WaitForSeconds(invisible);
        ToBlink.SetActive(true);
        yield return new WaitForSeconds(visible);
        StartCoroutine(blink());
        yield return null;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
