using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;
using Yarn.Unity;
public class DialogueTrigger : MonoBehaviour
{
    public NPC Target;
    public bool triggerPath = false;
    public int pathNum = 0;
    PlayerCharacter player;
    CharacterController playerCtrl;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void OnTriggerEnter(Collider other)
    {

        player = other.GetComponentInParent<PlayerCharacter>();
        if(player != null)
        {
            if (triggerPath)
            {
                playerCtrl = other.GetComponentInParent<CharacterController>();
                Waypoints w = Target.GetComponent<Waypoints>();
                w.onPathDone.AddListener(startDialogue);
                w.pathindex = pathNum;
                player.enabled = false;
                playerCtrl.enabled = false;

            }
            else
            {
                startDialogue();

            }

        }

    }
    public void startDialogue()
    {
        if (triggerPath)
        {
            player.enabled = true;
            playerCtrl.enabled = true;

            Waypoints w = Target.GetComponent<Waypoints>();
            w.onPathDone.RemoveListener(startDialogue);
        }
        Target.OnConversationStart();
        FindObjectOfType<DialogueRunner>().StartDialogue(Target.talkToNode);
    }
}
