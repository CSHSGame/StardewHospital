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
                break;
            case facing.Side:
                Front.gameObject.SetActive(false);
                Side.gameObject.SetActive(true);
                Back.gameObject.SetActive(false);
                break;
            case facing.Back:
                Front.gameObject.SetActive(false);
                Side.gameObject.SetActive(false);
                Back.gameObject.SetActive(true);
                break;
        }
    }
    public void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
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
       
        
        
       
    }
}
