using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRight : MonoBehaviour {
    public int pageNumber = 1;
    public GameObject page1;
    public GameObject page2;
	// Use this for initialization



    void OnMouseDown()
    {
        print("click");
        if (pageNumber < 3 && pageNumber > 0)
        {
            pageNumber++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (pageNumber >= 3)
        {
            pageNumber = 1;      
        }

        if (pageNumber == 1)
        {
            page1.gameObject.SetActive(true);
            page2.gameObject.SetActive(false);
        }

        if (pageNumber == 2)
        {
            page1.gameObject.SetActive(false);
            page2.gameObject.SetActive(true);
        }
    }
}
