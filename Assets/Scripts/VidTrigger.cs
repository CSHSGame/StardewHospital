using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidTrigger : MonoBehaviour {

    public VideoManager vidManager;
    private bool DoOnce = false;

    public enum CharacterVid { Syd, Williams, Eve, Marie, Lee };

    public CharacterVid charVid;

    public DayManager dayManager;

    public int dayCheckIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (DoOnce == false)
        {
            Debug.Log("Enter");
            if (other.gameObject.tag == "Player")
            {
                if (dayCheckIndex == dayManager.currentDay)
                {
                    Debug.Log("Correct Day");
                    vidManager.PlayVid((int)charVid);
                }
            }
            DoOnce = true;
        }
    }
}
