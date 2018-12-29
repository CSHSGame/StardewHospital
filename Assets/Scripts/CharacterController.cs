using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {


    public float speed;
    private Vector3 direction;
    //public SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
     
    }

   
    void Update()
    {
        //direction = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        direction.z = 0.0f;
        direction.x = 0.0f;

        if ((Input.GetKey(KeyCode.W))||(Input.GetKey(KeyCode.UpArrow)))
        {
            direction.z = 1.0f;
        }
        else if ((Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.DownArrow)))
        {
            direction.z = -1.0f;
        }
        else if ((Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.LeftArrow)))
        {
            direction.x = -1.0f;
        }
        else if ((Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.RightArrow)))
        {
            direction.x = 1.0f;
        }





        transform.position += direction * speed * Time.deltaTime;

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
