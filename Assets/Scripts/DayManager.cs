using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    NpcLoader npcLoader;
    ObjectiveLoader objectiveLoader;
    public DayDataHolder[] Days;
    public int currentDay = 0;
    // Use this for initialization
    void Start ()
    {
        npcLoader = GetComponent<NpcLoader>();
        objectiveLoader = GetComponent<ObjectiveLoader>();

        npcLoader.Setup(Days[currentDay]);
        objectiveLoader.Setup(Days[currentDay].Objectives);
    }
	[ContextMenu("changeDay")]
    public void IncrementDay()
    {
        currentDay++;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
