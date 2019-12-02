using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterCreationUI : MonoBehaviour
{
    public GameObject[] bodyParts;
   // public Image head;
    public int currentBodyPartIndex;

   
	// Use this for initialization
	void Start ()
    {
		
	}
    public void setPart(int index)
    {
        bodyParts[currentBodyPartIndex].SetActive(false);
        if(index >0 && index < bodyParts.Length)
        {
            currentBodyPartIndex = index;
        }
        bodyParts[currentBodyPartIndex].SetActive(true);

    }
    public void changeHeadLeft()
    {
        bodyParts[currentBodyPartIndex].SetActive(false);

        currentBodyPartIndex--;
        if(currentBodyPartIndex < 0)
        {
            currentBodyPartIndex = bodyParts.Length -1;
        }
        bodyParts[currentBodyPartIndex].SetActive(true);
    }
    public void changeHeadRight()
    {
        bodyParts[currentBodyPartIndex].SetActive(false);

        currentBodyPartIndex++;
        if (currentBodyPartIndex >= bodyParts.Length)
        {
            currentBodyPartIndex = 0;
        }
        // Debug.Log(currentHead);
        bodyParts[currentBodyPartIndex].SetActive(true);

    }
    // Update is called once per frame
    void Update ()
    {
		
	}
}
