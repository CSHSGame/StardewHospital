using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public enum facing { Front,Side,Back}
    public facing currentFacing = facing.Front;
    public Transform Front;
    public Transform Side;
    public Transform Back;
    public Animator FrontAnim;
    public Animator SideAnim;
    public Animator BackAnim;
    public bool walkingForward;
    public bool walkingSide;
    public bool walkingBack;

    [ContextMenu("setup References")]
    public void setupReferences()
    {
        Front = transform.Find("Front");
        Side = transform.Find("Side");
        Back = transform.Find("Back");
    }

    [ContextMenu("Apply Facing")]
    public void ApplyFacing()
    {
        switch (currentFacing)
        {
            case facing.Front:
                Front.gameObject.SetActive(true);
                Side.gameObject.SetActive(false);
                Back.gameObject.SetActive(false);
                if(FrontAnim != null)
                {
                    FrontAnim.SetBool("WalkingForward", walkingForward);

                }
                break;
            case facing.Side:
                Front.gameObject.SetActive(false);
                Side.gameObject.SetActive(true);
                Back.gameObject.SetActive(false);
                if (SideAnim != null)
                {
                    SideAnim.SetBool("WalkingSide", walkingSide);
                }
                break;
            case facing.Back:
                Front.gameObject.SetActive(false);
                Side.gameObject.SetActive(false);
                Back.gameObject.SetActive(true);
                if(BackAnim != null)
                {
                    BackAnim.SetBool("WalkingBack", walkingBack);

                }
                break;
        }

    }
    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (v < 0)
        {
            currentFacing = facing.Front;
            ApplyFacing();
        }
        else if (v > 0)
        {
            currentFacing = facing.Back;
            ApplyFacing();
        }
        else if(h > 0)
        {
            currentFacing = facing.Side;
            Side.localScale = Vector3.one;

            ApplyFacing();
        }
        else if (h < 0)
        {
            currentFacing = facing.Side;
            Side.localScale = new Vector3(-1, 1, 1);
            ApplyFacing();
        }
        else
        {
            if (FrontAnim != null && FrontAnim.isActiveAndEnabled)
            {
                FrontAnim.SetBool("WalkingForward", walkingForward);
            }
            else if (SideAnim != null && SideAnim.isActiveAndEnabled)
            {
                SideAnim.SetBool("WalkingSide", walkingSide);
            }
            else if (BackAnim != null && BackAnim.isActiveAndEnabled)
            {
                BackAnim.SetBool("WalkingBack", walkingBack);
            }
        }
    }
}
