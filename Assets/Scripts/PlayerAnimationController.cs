using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    public Animator movementAnimator;
    private bool isWalkingForward;
    private bool isWalkingBackward;
    private bool isWalkingLeftOrRight;

	// Use this for initialization
	void Start () {
        movementAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        

        
        AnimationInputHandler();
        AnimationSetter();
        
       
    }

    private void AnimationInputHandler()
    {
        isWalkingBackward = false;
        isWalkingForward = false;
        isWalkingLeftOrRight = false;


        if (Input.GetKey(KeyCode.W))
        {
            isWalkingBackward = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            isWalkingForward = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isWalkingLeftOrRight = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isWalkingLeftOrRight = true;
        }
    }
    
    private void AnimationSetter()
    {
        movementAnimator.SetBool("IsWalkingBackward", isWalkingBackward);

        movementAnimator.SetBool("IsWalkingForward", isWalkingForward);

        movementAnimator.SetBool("IsWalkingLeftRight", isWalkingLeftOrRight);
    }

}
