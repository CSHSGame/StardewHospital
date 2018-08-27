using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour {

    public Transform holdPosR;
    public Transform holdPosL;
    public Transform placement;
    public GameObject williams;
    public GameObject photo;
    public GameObject williamsInBed;
    public Transform photoInBed;


    bool held;
    SpriteRenderer playerSpriteRenderer;
	
	// Update is called once per frame
	void Update () {
        if (held == true)
        {
            if (playerSpriteRenderer.flipX == true)
            {
                transform.localPosition = holdPosR.transform.position;
            }
        
            if (playerSpriteRenderer.flipX == false)
            {
                transform.localPosition = holdPosL.transform.position;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Table")
        {
            print("Table");
            transform.position = placement.transform.position;
            held = false;
            Destroy(this);
            
        }

        if (other.gameObject.name == "Player Sprite"){
            playerSpriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
            held = true;
            //williams.transform.position = williamsInBed.position;
            williams.gameObject.SetActive(false);
            williamsInBed.gameObject.SetActive(true);
            photo.transform.position = photoInBed.position;

        }

    }
}
