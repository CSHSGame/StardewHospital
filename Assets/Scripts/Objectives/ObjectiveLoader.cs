using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Yarn.Unity;

public class ObjectiveLoader : MonoBehaviour
{
    public Text displayText;
  
    public Dictionary<string, ObjectiveData> keyValuePairs;
    public ObjectiveData[] Objectives;
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
        keyValuePairs = new Dictionary<string, ObjectiveData>();

        foreach (ObjectiveData o in Objectives)
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
