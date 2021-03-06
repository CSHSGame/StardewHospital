﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DayDataHolder : ScriptableObject
{
    public EndOfDayReviewNote[] DecisionPoints;
    [Space]

    public string[] otherVariables;
    [Space]

    public int CurrentDay;
    [Space]

    public ObjectiveData[] Objectives;
    [Space]
    public NpcDayData PlayerData;
    [Space]

    public NpcDayData[] npcs;
    [Header("UI")]
    public string DayOfTheWeek; // 3 Character
    public string DayNumber; // 2 Digits
    public string Month; // 3-4 Characters
    public string TimeOfDay; // 12:00 Time Format
    public bool AMOrPM; // AM false, PM true
}
