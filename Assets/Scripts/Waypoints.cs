using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Yarn.Unity;
[SelectionBase]
public class Waypoints : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent onPathDone;
    //public WayPointsHolder[] holder;
    public List< pointsVector3>Paths;
    public NpcDayData data;

    public float speed;
    private float oldSpeed;
    private float step;
    [SerializeField]
    public int pathindex = -1;
    [SerializeField]

    private int nodeindex = 0;
    public bool isPlayer;
    private Vector3 CamLocalPos;

    [SerializeField]
    bool warp = false;
    bool teleport = false;

    [YarnCommand("SetPath")]
    public void StartPathing(string Pathnum, string WarpType)
    {
        if (WarpType == "Warp")
        {
            warp = true;
            if (isPlayer)
            {
                GameObject cam = Camera.main.gameObject; ;
                CamLocalPos = cam.transform.localPosition;
                cam.transform.SetParent(null);
            }
        }
        else
        {
            teleport = true;
        }

        StartPathing(Pathnum);
    }

    [YarnCommand("SetPath")]
    public void StartPathing(string Pathnum)
    {
        Debug.Log(gameObject.name +" called " + Pathnum);
        int returnValue = ConvertStringToInt(Pathnum);

        if(returnValue < Paths.Count)
        {
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
        else
        {
            Debug.Break();
            Debug.LogError("Path # " + returnValue.ToString() + " not set in for " + gameObject.name +" Tell Julian or Pier");
        }
    
    }

    
    //public void OnDrawGizmosSelected()
    //{
    //    if(pathindex!= -1)
    //    {
            
    //        for (int i = 0; i< holder[pathindex].points.Length;i++ )
    //        {
    //            if (i == 0)
    //            {
    //                Gizmos.DrawLine(transform.position, holder[pathindex].points[i].transform.position);
    //            }
    //            else
    //            {
    //                Gizmos.DrawLine(holder[pathindex].points[i-1].transform.position, holder[pathindex].points[i].transform.position);
    //            }
                
    //        }
    //    }
        
    //}
    // Use this for initialization
    void Start ()
    {
        pathindex = -1;
        nodeindex = 0;
        oldSpeed = speed;
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
            if (nodeindex < Paths[pathindex].location.Count)
            {
                //Move our position a step closer to the target.
                this.transform.position = Vector3.MoveTowards(this.transform.position, Paths[pathindex].location[nodeindex], step);

                //If we've reached the destination, move to the next one
                if (this.transform.position == Paths[pathindex].location[nodeindex])
                {
                    nodeindex++;

                    if (warp)
                    {
                        if(nodeindex >= 2 && nodeindex < Paths[pathindex].location.Count - 1)
                        {
                           
                            speed = 10;
                            if (isPlayer)
                            {
                                Camera.main.cullingMask = 0;
                            }

                        }
                        if (nodeindex == Paths[pathindex].location.Count - 1)
                        {
                            speed = oldSpeed;
                            if (isPlayer)
                            {
                                GameObject cam = Camera.main.gameObject;

                                cam.transform.position = Paths[pathindex].location[Paths[pathindex].location.Count - 1];
                                cam.transform.position += Vector3.up * 3;
                                Camera.main.cullingMask = -1;
                            }

                        }
                    }
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

                    if (warp)
                    {
                        GameObject cam = Camera.main.gameObject;

                        cam.transform.SetParent(this.gameObject.transform);
                        cam.transform.localPosition = CamLocalPos;
                    }
                   
                }
                Debug.Log("Break");
                pathindex = -1;
                nodeindex = 0;

                warp = false;

                onPathDone.Invoke();
            }
        }
    }
    public void BakeData()
    {
        data.waypoints = new pointsVector3[Paths.Count];

        for(int i = 0; i < Paths.Count;i++)
        {
            data.waypoints[i] = Paths[i];
        }





    }
    public void loadData()
    {
        Paths = new List<pointsVector3>() ;
        for (int i = 0; i < data.waypoints.Length; i++)
        {
            Paths.Add(data.waypoints[i]);
        }
    }
}
