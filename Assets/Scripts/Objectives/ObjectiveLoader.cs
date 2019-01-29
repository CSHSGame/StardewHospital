using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Yarn.Unity;

public class ObjectiveLoader : MonoBehaviour
{
    public Text displayText;
    [System.Serializable]
    public struct objective
    {
        public string name;
        public enum Npc { william, nurse, clara}
        public Npc target;
        public int wayfindingIndex;
        public string displayText;
    }
    public Dictionary<string, objective> keyValuePairs;
    public objective[] Objectives;
    public ObjectiveData[] Objectives2;
    public MapController map;
    public string test;
    [ContextMenu("start search")]
    public void startSearch()
    {
        map.StartSearch(5);
    }
    // Use this for initialization
	void Start ()
    {
        keyValuePairs = new Dictionary<string, objective>();

        foreach (objective o in Objectives)
        {
            keyValuePairs.Add(o.name, o);
        }
	}
    [ContextMenu ("SetObjective")]
    public void testo()
    {
        SetObjective(test);
    }

    [YarnCommand("SetObjective")]
    public void SetObjective(string name  )
    {
        if (keyValuePairs.ContainsKey(name))
        {
            displayText.text = keyValuePairs[name].displayText;
            map.StartSearch(keyValuePairs[name].wayfindingIndex);

        }
    }
        // Update is called once per frame
    void Update () {
		
	}
}
