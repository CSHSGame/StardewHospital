using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoManager : MonoBehaviour {

    public bool VidPlaying = false;

    public VideoPlayer vidPlayer;
    public GameObject[] behaviors;

    
    public BoxCollider SydIntroTrigger;

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
        yield return new WaitForSeconds(0.15f);
        foreach (GameObject mono in behaviors)
        {
            mono.SetActive(true);
        }
    }

    //public void PlaySydVid()
    //{
    //    vidPlayer.clip = SydIntroClip;
    //    foreach (GameObject mono in behaviors)
    //    {
    //        mono.SetActive(true);
    //    }
    //}

    //public void PlayWilliamsVid()
    //{
    //    vidPlayer.clip = WilliamsIntroClip;
    //    foreach (GameObject mono in behaviors)
    //    {
    //        mono.SetActive(true);
    //    }
    //}

    //public void PlayEveVid()
    //{
    //    vidPlayer.clip = EveIntroClip;
    //    foreach (GameObject mono in behaviors)
    //    {
    //        mono.SetActive(true);
    //    }
    //}

    //public void PlayMarieVid()
    //{
    //    vidPlayer.clip = MarieIntroClip;
    //    foreach (GameObject mono in behaviors)
    //    {
    //        mono.SetActive(true);
    //    }
    //}

    //public void PlayLeeVid()
    //{
    //    vidPlayer.clip = LeeIntroClip;
    //    foreach (GameObject mono in behaviors)
    //    {
    //        mono.SetActive(true);
    //    }
    //}
}
