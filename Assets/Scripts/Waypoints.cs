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

    public int nodeindex = 0;
    public bool isPlayer;
    private Vector3 CamLocalPos;

    [SerializeField]
    bool warp = false;
    bool teleport = false;
    public bool selfMover;
    public bool loopSelfMove = true;

    public IBodyPart[] bodyParts;
    public void Start()
    {
        pathindex = -1;
        nodeindex = 0;
        oldSpeed = speed;
        if (selfMover)
        {
            SelfMove();
        }
    }
    private void Setup()
    {
        if(bodyParts == null)
        {
            bodyParts = GetComponentsInChildren<IBodyPart>();

        }

    }
    // Update is called once per frame
    void Update()
    {

        // The step size is equal to speed times frame time.
        step = speed * Time.deltaTime;
        if (pathindex != -1) //pathindex is set from yarn in most cases 
        {
            if (nodeindex < Paths[pathindex].location.Count)
            {
                //Move our position a step closer to the target.
                this.transform.position = Vector3.MoveTowards(this.transform.position, Paths[pathindex].location[nodeindex], step);
                Vector3 direction = ( Paths[pathindex].location[nodeindex] - transform.position).normalized;

                foreach (IBodyPart bp in bodyParts)
                {
                    if(Mathf.Abs( direction.x )> Mathf.Abs(direction.z))
                    {
                        bp.ReceiveInput(new Vector2(direction.x, 0));

                    }
                    else
                    {
                        bp.ReceiveInput(new Vector2(0, direction.z));

                    }
                }
                //If we've reached the destination, move to the next one
                if (this.transform.position == Paths[pathindex].location[nodeindex])
                {
                    moveToNextNode();
                }
            }
            else  //pathing Complete
            {
                completePath();
            }
        }
        /*
        if (selfMover)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + new Vector3(1, 0, 0), step);

            Vector3 direction = (this.transform.position + new Vector3(1, 0, 0) - transform.position).normalized;

            foreach (IBodyPart bp in bodyParts)
            {
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
                {
                    bp.ReceiveInput(new Vector2(direction.x, 0));

                }
                else
                {
                    bp.ReceiveInput(new Vector2(0, direction.z));

                }
            }
        }*/
        if (selfMover)
        {
            if (pathindex != -1) //pathindex is set from yarn in most cases 
            {
                if (nodeindex < Paths[pathindex].location.Count)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, Paths[pathindex].location[nodeindex], step);

                    Vector3 direction = (Paths[pathindex].location[nodeindex] - transform.position).normalized;

                    foreach (IBodyPart bp in bodyParts)
                    {
                        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
                        {
                            bp.ReceiveInput(new Vector2(direction.x, 0));

                        }
                        else
                        {
                            bp.ReceiveInput(new Vector2(0, direction.z));

                        }
                    }
                    //If we've reached the destination, move to the next one
                    if (this.transform.position == Paths[pathindex].location[nodeindex])
                    {
                        moveToNextNode();
                    }
                }
                else  //pathing Complete
                {
                    completePath();
                }
            }
        }
    }

    private void SelfMove()
    {
        Setup();
        pathindex = 0;
    }

    private void moveToNextNode()
    {
        nodeindex++;

        if (warp)
        {
            if (nodeindex >= 2 && nodeindex < Paths[pathindex].location.Count - 1) //second to last
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

    private void completePath()
    {
        
        if (isPlayer)
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
        if (loopSelfMove)
        {
            pathindex = 0;
            nodeindex = 0;
        }
    }

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
            //turns off collision
            foreach (Collider c in GetComponentsInChildren<Collider>())
            {
                c.enabled = false;
            }
            if (isPlayer)// if player turn off controls 
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
        Setup();
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
            case "Eleven": return 11;
            case "Twelve": return 12;

            default:
                Debug.Break();
                return -1;
        }
    }

    
    public void BakeData()
    {
        data.waypoints = new pointsVector3[Paths.Count];

        for(int i = 0; i < Paths.Count;i++)
        {
            data.waypoints[i] = Paths[i];
        }
        data.MoveSpeed = speed;
        data.selfMovement = selfMover;
        data.loopSelfMovement = loopSelfMove;

    }
    public void loadData()
    {
        Paths = new List<pointsVector3>() ;
        for (int i = 0; i < data.waypoints.Length; i++)
        {
            Paths.Add(data.waypoints[i]);
        }

        selfMover = data.selfMovement;
        speed = data.MoveSpeed;
        loopSelfMove = data.loopSelfMovement;
    }
}
