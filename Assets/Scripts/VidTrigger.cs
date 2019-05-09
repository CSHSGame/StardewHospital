using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidTrigger : MonoBehaviour {

    public VideoManager vidManager;
    private bool DoOnce = false;

    public enum CharacterVid { Syd, Williams, Eve, Marie, Lee };

    public CharacterVid charVid;



    private void OnTriggerEnter(Collider other)
    {
        if (DoOnce == false)
        {
            Debug.Log("Enter");
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Player");
                vidManager.PlayVid((int)charVid);
            }
            DoOnce = true;
        }
    }
}
