using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// store objectives data for 1 day
/// </summary>
[CreateAssetMenu]
public class ObjectiveData : ScriptableObject
{

    public string name;
    public enum Npc { william, nurse, clara }
    public Npc target;
    public int wayfindingIndex;
    public string displayText;

}
