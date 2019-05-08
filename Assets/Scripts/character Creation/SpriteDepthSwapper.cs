using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDepthSwapper : MonoBehaviour {

    public List<BoxCollider> sprites;
    public List<SpriteRenderer> mySprites;

    private BoxCollider myBoxCollider;
    public int CurrentLayer = 0;
	// Use this for initialization
	void Start ()
    {
        myBoxCollider = GetComponent<BoxCollider>();
        sprites = new List<BoxCollider>();
        foreach (BoxCollider box in FindObjectsOfType<BoxCollider>())
        {
            if(box.isTrigger == false && box.gameObject.tag != "wall"  && box.gameObject.tag != "Player")
            { 
                sprites.Add(box);
            }
        }

        Comp comparer = new Comp();
        sprites.Sort(comparer);
        sprites.Reverse();

        int layer = 0;
        for(int i = 0; i < sprites.Count;i++ )
        {
            sprites[i].GetComponent<SpriteRenderer>().sortingOrder = layer;
            layer+=2;
        }
        mySprites = new List<SpriteRenderer>();
        foreach (BodyPart b in GetComponentsInChildren<BodyPart>())
        {
            b.Front.gameObject.SetActive(true);
            mySprites.Add(b.Front.GetComponentInChildren<SpriteRenderer>());

            b.Side.gameObject.SetActive(true);
            mySprites.Add(b.Side.GetComponentInChildren<SpriteRenderer>());

            b.Back.gameObject.SetActive(true);
            mySprites.Add(b.Back.GetComponentInChildren<SpriteRenderer>());

            b.ApplyFacing();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < sprites.Count;i++)
        {
            if(sprites[i] != null && sprites[i].transform.TransformPoint(sprites[i].center).z > transform.TransformPoint(myBoxCollider.center).z)
            {
                CurrentLayer = sprites[i].GetComponent<SpriteRenderer>().sortingOrder + 1;
                  
            }

           // break;
        }
        foreach(SpriteRenderer s in mySprites)
        {
            if (s != null)
            {
                s.sortingOrder = CurrentLayer;

            }
        }
    }
}
public class Comp : IComparer<BoxCollider>
{
    public int Compare(BoxCollider x, BoxCollider y)
    {
        if (x == null)
        {
            if (y == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
        else
        {
            if (y == null)
            {
                return -1;
            }
            else
            {
               
                int difference =  (Mathf.RoundToInt(x.transform.TransformPoint(x.center).z) - Mathf.RoundToInt(y.transform.TransformPoint(y.center).z ));

                if (difference != 0)
                {
                    return difference;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}