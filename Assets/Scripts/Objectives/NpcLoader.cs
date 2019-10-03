using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;
public class NpcLoader : MonoBehaviour
{
    public DayDataHolder dayDataHolder;
    public Transform prefab;
    // Use this for initialization
    public void Setup (DayDataHolder day)
    {
        Debug.Log("setup");
        dayDataHolder = day;
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        LoadNpc();

    }
    [ContextMenu("delete npc")]
    public void DeleteNpc()
    {
        var tempArray = new GameObject[transform.childCount];
        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = transform.GetChild(i).gameObject;
        }

        foreach (var child in tempArray)
        {
            DestroyImmediate(child);
        }

    }
    [ContextMenu("load npc")]
    public void LoadNpc()
    {

        Debug.Log("LoadNPC");
        for (int i = 0; i < dayDataHolder.npcs.Length; i++)
        {
            Yarn.Unity.Example.NPC npc = Instantiate(prefab).GetComponent<Yarn.Unity.Example.NPC>();
            npc.data = dayDataHolder.npcs[i];
            npc.LoadData();
            Waypoints pt = npc.GetComponent<Waypoints>();
            pt.data = dayDataHolder.npcs[i];
            pt.loadData();

            if (dayDataHolder.npcs[i].scriptToLoad != null)
            {
                FindObjectOfType<Yarn.Unity.DialogueRunner>().AddScript(dayDataHolder.npcs[i].scriptToLoad);

            }
            npc.transform.SetParent(this.transform);

            if(npc.data.DialogueTriggerPrefab != null)
            {
                Instantiate(npc.data.DialogueTriggerPrefab).GetComponent<DialogueTrigger>().Target = npc ;
            }
        }

        Waypoints player = GameObject.FindObjectOfType<PlayerCharacter>().GetComponent<Waypoints>();
        player.data = dayDataHolder.PlayerData;
        player.loadData();
        player.transform.position = new Vector3(-0.98f, 0.13f, 3.03f);
        player.onPathDone.RemoveAllListeners();
    }
    // Update is called once per frame
    void Update () {
		
	}

}
