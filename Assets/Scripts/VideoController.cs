using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public Slider mySlider; 
    public UnityEvent OnVideoDone;
    // Use this for initialization
    private VideoPlayer vp;

    //public 
    void Start ()
    {
        vp = gameObject.GetComponent<VideoPlayer>();
        vp.loopPointReached += EndReached;
	}
	void EndReached(VideoPlayer p)
    {
        OnVideoDone.Invoke();
    }
    public void onvalChange(float time)
    {
        vp.time =  vp.clip.length* time;

        Debug.Log(time);
    }
	// Update is called once per frame
	void Update ()
    {
        mySlider.value = (float)(vp.time / vp.clip.length);
	}
}
