using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
[SelectionBase]
public class Waypoints : MonoBehaviour {

    public WayPointsHolder[] holder;
    public WaypointsAsset test;

    public float speed;
    private float step;
    [SerializeField]
    private int pathindex = -1;
    private int nodeindex = 0;

    public bool isPlayer;

    [YarnCommand("SetPath")]
    public void StartPathing(string Pathnum)
    {
        Debug.Log("called " + Pathnum);
        int returnValue = ConvertStringToInt(Pathnum);
        pathindex = returnValue;

        foreach (Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = false;
        }
        if (isPlayer)
        {
            GetComponent<CharacterController>().enabled = false;
            GetComponent<Yarn.Unity.Example.PlayerCharacter>().enabled = false;

        }
    }

    
    public void OnDrawGizmosSelected()
    {
        if(pathindex!= -1)
        {
            
            for (int i = 0; i< holder[pathindex].points.Length;i++ )
            {
                if (i == 0)
                {
                    Gizmos.DrawLine(transform.position, holder[pathindex].points[i].transform.position);
                }
                else
                {
                    Gizmos.DrawLine(holder[pathindex].points[i-1].transform.position, holder[pathindex].points[i].transform.position);
                }
                
            }
        }
        
    }
    // Use this for initialization
    void Start ()
    {
        
    }

    int ConvertStringToInt(string number)
    {
        switch (number)
        {
            case "Zero": return 0;
            case "One": return 1;
            case "Two": return 2;
            case "Three": return 3;
            case "Four": return 4;
            case "Five": return 5;
            case "Six": return 6;
            case "Seven": return 7;
            case "Eight": return 8;
            case "Nine": return 9;
            case "Ten": return 10;

            default:
                Debug.Break();
                return -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // The step size is equal to speed times frame time.
        step = speed * Time.deltaTime;
        if (pathindex != -1)
        {
            if (nodeindex < holder[pathindex].points.Length)
            {
                //Move our position a step closer to the target.
                this.transform.position = Vector3.MoveTowards(this.transform.position, holder[pathindex].points[nodeindex].transform.position, step);

                //If we've reached the destination, move to the next one
                if (this.transform.position == holder[pathindex].points[nodeindex].transform.position)
                {
                    nodeindex++;
                }
            }
            else
            {
                if(isPlayer)
                {
                    GetComponent<CharacterController>().enabled = true;
                    GetComponent<Yarn.Unity.Example.PlayerCharacter>().enabled = true;
                    foreach (Collider c in GetComponentsInChildren<Collider>())
                    {
                        c.enabled = true;
                    }
                }
                Debug.Log("Break");
                pathindex = -1;
                nodeindex = 0;
            }
        }
    }

    
}
