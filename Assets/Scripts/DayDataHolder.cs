using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DayDataHolder : ScriptableObject
{
    public EndOfDayReviewNote[] DecisionPoints;
    public string[] otherVariables;
    public int CurrentDay;
    public ObjectiveData[] Objectives;

    public NpcDayData[] npcs;
}
