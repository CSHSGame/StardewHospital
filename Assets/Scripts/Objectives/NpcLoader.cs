using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLoader : MonoBehaviour
{
    public DayDataHolder dayDataHolder;
    // Use this for initialization
    void Start () {
		for (int i= 0; i < dayDataHolder.npcs.Length; i++)
        {
            Yarn.Unity.Example.NPC npc = Instantiate(dayDataHolder.npcs[i].prefab).GetComponent< Yarn.Unity.Example.NPC>();
            npc.transform.position = dayDataHolder.npcs[i].position;
            npc.transform.localScale = dayDataHolder.npcs[i].scale;
            npc.transform.rotation = dayDataHolder.npcs[i].rotation;
            npc.gameObject.name = dayDataHolder.npcs[i].GameObjectName;
            npc.talkToNode = dayDataHolder.npcs[i].talkToNode;
            if(dayDataHolder.npcs[i].scriptToLoad != null)
            {
                FindObjectOfType<Yarn.Unity.DialogueRunner>().AddScript(dayDataHolder.npcs[i].scriptToLoad);

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
