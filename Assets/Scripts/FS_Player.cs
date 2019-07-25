using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FS_Player : MonoBehaviour
{

    [FMODUnity.EventRef]
    // public string InputFootsteps;
    FMOD.Studio.EventInstance FootstepsEvent;

    bool playerismoving;
    public float walkingspeed;
    private bool playerisgrounded;

    FMODUnity.StudioEventEmitter emitter;
    void Start()
    {
        var target = GameObject.Find("Player");
        emitter = target.GetComponent<FMODUnity.StudioEventEmitter>();
        
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }

    void Update()
    {   

    }

    void CallFootsteps()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)))
        {

            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            
        }
        else if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
        {

            GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
        else if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
        else if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }

    void OnDisable()
    {
        playerismoving = false;
    }

    void OnTriggerStay(Collider MaterialCheck)
    {
        //float FadeSpeed = 10f;
        //playerisgrounded = true;
        

        if (MaterialCheck.CompareTag("FS_Tile"))
        {
            emitter.SetParameter("Wood", 0);
            emitter.SetParameter("Tile", 1);
            emitter.SetParameter("Grass", 0);
            emitter.SetParameter("Pavement", 0);

        }

        if (MaterialCheck.CompareTag("FS_Wood"))
        {
            emitter.SetParameter("Wood", 1);
            emitter.SetParameter("Tile", 0);
            emitter.SetParameter("Grass", 0);
            emitter.SetParameter("Pavement", 0);

        }

        if (MaterialCheck.CompareTag("FS_Grass"))
        {
            emitter.SetParameter("Wood", 0);
            emitter.SetParameter("Tile", 0);
            emitter.SetParameter("Grass", 1);
            emitter.SetParameter("Pavement", 0);

        }
        if (MaterialCheck.CompareTag("FS_Pavement"))

        {
            emitter.SetParameter("Wood", 0);
            emitter.SetParameter("Tile", 0);
            emitter.SetParameter("Grass", 0);
            emitter.SetParameter("Pavement", 1);

        }
    }

    void OnTriggerExit(Collider MaterialCheck)
    {
        //playerisgrounded = false;
    }

}


