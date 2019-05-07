using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimController : MonoBehaviour, IBodyPart
{
    public RuntimeAnimatorController test;
    public Animator myAnimator;
    public enum facing { Front, Side, Back }
    public facing currentFacing = facing.Front;

    public float h = 0;
    public float v = 0;
    private bool moving;
    public void ReceiveInput(Vector2 input)
    {
        h = input.x;
        v = input.y;
      //  Debug.Log("yooo");
    }
    // Use this for initialization
    void Start () {
        Setup();

    }
	public void Setup()
    {
        myAnimator.runtimeAnimatorController = test;
    }
    // Update is called once per frame
    void Update() {

        if (v < 0)
        {
            currentFacing = facing.Front;
            //walkingForward = true;
            // walkingBack = false;
            // walkingSide = false;
            // ApplyFacing();
            moving = true;

        }
        else if (v > 0)
        {
            currentFacing = facing.Back;
            //  walkingForward = false;
            // walkingBack = true;
            // walkingSide = false;
            // ApplyFacing();
            moving = true;

        }
        else if (h > 0)
        {
            currentFacing = facing.Side;
            transform.localScale = Vector3.one;
            //walkingForward = false;
            //walkingBack = false;
            //walkingSide = true;
            // ApplyFacing();
            moving = true;

        }
        else if (h < 0)
        {

            currentFacing = facing.Side;
            transform.localScale = new Vector3(-1, 1, 1);
            // walkingForward = false;
            // walkingBack = false;
            // walkingSide = true;
            // ApplyFacing();
            moving = true;

        }
        else
        {
            currentFacing = facing.Front;

            //    walkingForward = false;
            // walkingBack = false;
            //  walkingSide = false;
            //  ApplyFacing();
            moving = false;

        }
        if(myAnimator != null && myAnimator.runtimeAnimatorController != null)
        {
            myAnimator.SetInteger("Facing", (int)currentFacing);

            myAnimator.SetBool("Moving", moving);
        }
       
    }
}
