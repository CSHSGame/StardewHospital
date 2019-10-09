using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using UnityEngine.Video;
using FMODUnity;

public class VideoManager : MonoBehaviour
{

    public bool VidPlaying = false;

    public VideoPlayer vidPlayer;
    public GameObject[] behaviors;

    //public VideoClip SydIntroClip;
    //public VideoClip WilliamsIntroClip;
    //public VideoClip EveIntroClip;
    //public VideoClip MarieIntroClip;
    //public VideoClip LeeIntroClip;

    public VideoClip[] vidClip;

    private void Update()
    {
        if(vidPlayer.isPlaying)
        {
            VidPlaying = true;
            //this.gameObject.GetComponent<StudioEventEmitter>()
        }
        else
        {
            VidPlaying = false;
        }
    } 

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


    public void PlayVid(int vid)
    {
        vidPlayer.clip = vidClip[vid];
        StartCoroutine(LoadVideoWait());
       
    }

    IEnumerator LoadVideoWait()
    {
        yield return new WaitForSeconds(0.25f);
        foreach (GameObject mono in behaviors)
        {
            mono.SetActive(true);
        }
    }
}
