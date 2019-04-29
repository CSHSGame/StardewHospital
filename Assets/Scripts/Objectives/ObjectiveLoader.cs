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
    public string targetObjective;
    public int currentObjective = 0;
    [ContextMenu("start search")]
    public void startSearch()
    {
        map.StartSearch(5);
    }
    // Use this for initialization
    public void Setup (ObjectiveData[] day)
    {

        Objectives = day;
        keyValuePairs = new Dictionary<string, ObjectiveData>();

        foreach (ObjectiveData o in Objectives)
        {
            keyValuePairs.Add(o.name, o);
        }
        targetObjective = Objectives[currentObjective].name;
        SetObjective(targetObjective);

    }

    public void IncrementObjective()
    {
        currentObjective++;
    }
    [ContextMenu ("SetObjective")]
    public void testo()
    {
        SetObjective(targetObjective);
    }

    [YarnCommand("SetObjective")]
    public void SetObjective(string name  )
    {
        if (keyValuePairs.ContainsKey(name))
        {
            if(displayText!= null)
            {
                displayText.text = keyValuePairs[name].displayText;
            }

            map.StartSearch(keyValuePairs[name].wayfindingIndex);
            Debug.Log("objective set to " + name);
        }
        else
        {
            Debug.LogError("objective " + name + " does not exist");
        }
    }
        // Update is called once per frame
    void Update () {
		
	}
}
