using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad : MonoBehaviour
{
    public CharacterData Assets;
	// Use this for initialization
	void Start ()
    {
        Load();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        CharacterSaveData data = (CharacterSaveData)SaveManager.Load("charData");

        if (data != null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            Instantiate(Assets.heads[data.headIndex], this.transform);
            Instantiate(Assets.Bodies[data.bodyIndex], this.transform);
            ExampleVariableStorage variableStorage = GameObject.FindObjectOfType<ExampleVariableStorage>();
            if (variableStorage != null)
            {
                //Debug.Log("player name "+ data.CharacterName);
                Debug.Log("player name " + variableStorage.GetValue("$playerName").AsString);

                variableStorage.SetValue("$playerName", new Yarn.Value(data.CharacterName));
                Debug.Log("player name " + variableStorage.GetValue("$playerName").AsString);

                // variableStorage.defaultVariables.SetValue(data.CharacterName, 0);
            }
        }
    }
    [ContextMenu ("checkName")]
    public void CheckName()
    {
        ExampleVariableStorage variableStorage = GameObject.FindObjectOfType<ExampleVariableStorage>();

        Debug.Log("player name " + variableStorage.GetValue("$playerName").AsString);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
