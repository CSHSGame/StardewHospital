using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public GameObject[] points;
    public GameObject character;
    public float speed;

    private int index = 0;

	// Use this for initialization
	void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        if (index < points.Length)
        {
            // Move our position a step closer to the target.
            character.transform.position = Vector3.MoveTowards(character.transform.position, points[index].transform.position, step);

            //If we've reached the destination, move to the next one
            if (character.transform.position == points[index].transform.position)
            {
                index++;
            }
        }
    }
}
