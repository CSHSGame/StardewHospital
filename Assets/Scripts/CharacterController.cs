using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using FMODUnity;

public class CharacterController : MonoBehaviour {


    public float speed;
    private Vector3 direction;
    private Rigidbody rb;
    public BodyPart bodyPartBody;
    public BodyPart bodyPartHead;
    public BodyPart bodyPartHair;

    public VideoManager vidManager;
    //public SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
   
    void Update()
    {
        //direction = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (FindObjectOfType<DialogueRunner>().isDialogueRunning == true)
        {
            return;
        }

        if (vidManager.VidPlaying == true)
        {
            return;
        }

        direction.z = 0.0f;
        direction.x = 0.0f;
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bodyPartBody.ReceiveInput(input);
        bodyPartHead.ReceiveInput(input);
        bodyPartHair.ReceiveInput(input);
        

        if((Input.GetKey(KeyCode.LeftShift)))
        {
            speed = 8.0f;
        }
        else
        {
            speed = 4.0f;
        }
        
        if ((Input.GetKey(KeyCode.W))||(Input.GetKey(KeyCode.UpArrow)))
        {
            direction.z = 1.0f;
            //bodyPartBody.walkingBack = true;
            //bodyPartBody.walkingForward = false;
            //bodyPartBody.walkingSide = false;

            //bodyPartHead.walkingBack = true;
            //bodyPartHead.walkingForward = false;
            //bodyPartHead.walkingSide = false;

            //bodyPartHair.walkingBack = true;
            //bodyPartHair.walkingForward = false;
            //bodyPartHair.walkingSide = false;
        }
        else if ((Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.DownArrow)))
        {
            direction.z = -1.0f;
            //bodyPartBody.walkingForward = true;
            //bodyPartBody.walkingBack = false;
            //bodyPartBody.walkingSide = false;

            //bodyPartHead.walkingForward = true;
            //bodyPartHead.walkingBack = false;
            //bodyPartHead.walkingSide = false;

            //bodyPartHair.walkingForward = true;
            //bodyPartHair.walkingBack = false;
            //bodyPartHair.walkingSide = false;
        }
        else if ((Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.LeftArrow)))
        {
            direction.x = -1.0f;
            //bodyPartBody.walkingSide = true;
            //bodyPartBody.walkingBack = false;
            //bodyPartBody.walkingForward = false;

            //bodyPartHead.walkingSide = true;
            //bodyPartHead.walkingBack = false;
            //bodyPartHead.walkingForward = false;

            //bodyPartHair.walkingSide = true;
            //bodyPartHair.walkingBack = false;
            //bodyPartHair.walkingForward = false;
        }
        else if ((Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.RightArrow)))
        {
            direction.x = 1.0f;
            //bodyPartBody.walkingSide = true;
            //bodyPartBody.walkingBack = false;
            //bodyPartBody.walkingForward = false;

            //bodyPartHead.walkingSide = true;
            //bodyPartHead.walkingBack = false;
            //bodyPartHead.walkingForward = false;

            //bodyPartHair.walkingSide = true;
            //bodyPartHair.walkingBack = false;
            //bodyPartHair.walkingForward = false;
        }
        else
        {
            //bodyPartBody.walkingBack = false;
            //bodyPartBody.walkingForward = false;
            //bodyPartBody.walkingSide = false;

            //bodyPartHead.walkingBack = false;
            //bodyPartHead.walkingForward = false;
            //bodyPartHead.walkingSide = false;

            //bodyPartHair.walkingBack = false;
            //bodyPartHair.walkingForward = false;
            //bodyPartHair.walkingSide = false;
        }



        rb.MovePosition(new Vector3((transform.position.x + direction.x * speed * Time.deltaTime),0, transform.position.z + direction.z * speed * Time.deltaTime));
     
      
        

        //transform.position += direction * speed * Time.deltaTime;
        


        if (direction.x == -1.0f)
        {
          //  sprite.flipX = false;
        }
        else if (direction.x == 1.0f)
        {
           // sprite.flipX = true;
        }
    }
}
