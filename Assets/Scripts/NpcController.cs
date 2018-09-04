using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour {
    public enum NpcState {  talking,walking, standing,interacting}
    // Use this for initialization
    public NpcState CurrentState;
    public GameObject Target;
    public bool isTalking = false;

    [SerializeField]
    private NavMeshAgent agent;

    public List<Transform> interactionPts;
	void Start () {
        agent.updateUpAxis = false;
        agent.updateRotation = false;

        agent.SetDestination(Target.transform.position);
    }

    // Update is called once per frame
    void Update () {
        switch (CurrentState)
        {
            case NpcState.talking:
                isTalking = false;
                break;
            case NpcState.walking:
                if (isTalking)
                {
                    CurrentState = NpcState.talking;
                }
                //if()
                break;
            case NpcState.standing:
                if (isTalking)
                {
                    CurrentState = NpcState.talking;
                }
                break;
            case NpcState.interacting:
                if (isTalking)
                {
                    CurrentState = NpcState.talking;
                }
                break;
        }
    }
}
