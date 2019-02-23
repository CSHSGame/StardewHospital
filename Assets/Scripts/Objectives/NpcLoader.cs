using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLoader : MonoBehaviour
{
    public DayDataHolder dayDataHolder;
    public Transform prefab;
    // Use this for initialization
    public void Setup (DayDataHolder day)
    {
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
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

}
