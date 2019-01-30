using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// holds npc data for a specific day 
/// </summary>
[CreateAssetMenu]
public class NpcDayData : ScriptableObject
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    // Use this for initialization
    public string talkToNode = "";
    public TextAsset scriptToLoad;
    public Transform prefab;

    [Header("waypints stuff")]
    public pointsVector3[] waypoints;
}
[System.Serializable]
public struct pointsVector3
{
    public string Name;

    public Vector3[] location;

}