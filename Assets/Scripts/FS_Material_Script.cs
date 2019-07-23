using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FS_Material_Script : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string InputFootsteps;
    FMOD.Studio.EventInstance FootstepsEvent;
    FMOD.Studio.ParameterInstance Material01Parameter;
    FMOD.Studio.ParameterInstance Material02Parameter;
    FMOD.Studio.ParameterInstance Material03Parameter;
	FMOD.Studio.ParameterInstance Material04Parameter;

    bool playerismoving;
    public float walkingspeed;
    private float Material01Value;
    private float Material02Value;
    private float Material03Value;
	private float Material04Value;
    private bool playerisgrounded;

    void Start()
    {
        FootstepsEvent = FMODUnity.RuntimeManager.CreateInstance(InputFootsteps);
        FootstepsEvent.getParameter("FS_Tile", out Material01Parameter);
        FootstepsEvent.getParameter("FS_Carpet", out Material02Parameter);
        FootstepsEvent.getParameter("FS_Pavement", out Material03Parameter);
		FootstepsEvent.getParameter("FS_Grass", out Material04Parameter);

        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }

    void Update()
    {
        Material01Parameter.setValue(Material01Value);
        Material02Parameter.setValue(Material02Value);
        Material03Parameter.setValue(Material03Value);
		Material04Parameter.setValue(Material04Value);

        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            if (playerisgrounded == true)
            {
                playerismoving = true;
            }
            else if (playerisgrounded == false)
            {
                playerismoving = false;
            }
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            playerismoving = false;
        }
    }

    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            FootstepsEvent.start();
        }
        else if (playerismoving == false)
        {
            //Debug.Log ("player is moving = false");
        }
    }

    void OnDisable()
    {
        playerismoving = false;
    }

    void OnTriggerStay(Collider MaterialCheck)
    {
        //float FadeSpeed = 10f;
        playerisgrounded = true;

        if (MaterialCheck.CompareTag("FS_Tile"))
        {
            Material01Value = 1f;
            Material02Value = 0f;
            Material03Value = 0f;
			Material04Value = 0f;
        }
        if (MaterialCheck.CompareTag("FS_Wood"))
        {
            Material01Value = 0f;
            Material02Value = 1f;
            Material03Value = 0f;
			Material04Value = 0f;
        }
        if (MaterialCheck.CompareTag("FS_Grass"))
        {
            Material01Value = 0f;
            Material02Value = 0f;
            Material03Value = 1f;
			Material04Value = 0f;
        }
		if (MaterialCheck.CompareTag("FS_Pavement"))
        {
            Material01Value = 0f;
            Material02Value = 0f;
            Material03Value = 0f;
			Material04Value = 1f;
        }
    }

    void OnTriggerExit(Collider MaterialCheck)
    {
        playerisgrounded = false;
    }
}

