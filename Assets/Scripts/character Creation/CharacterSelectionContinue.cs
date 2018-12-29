using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionContinue : MonoBehaviour
{
    public characterCreationUI headUI;
    public characterCreationUI bodyUI;
    public string characterName = "John";
    public int nextScene = 13;
    public void setName(string name)
    {
        characterName = name;
    }
    public void Complete()
    {
        Save();
        SceneManager.LoadScene(nextScene);
    }

    [ContextMenu("Save")]
    private void Save()
    {
        CharacterSaveData data = new CharacterSaveData();

        data.CharacterName = characterName;
        data.headIndex = headUI.currentHead;
        data.bodyIndex = bodyUI.currentHead;
        SaveManager.Save(data,"charData");

    }
    [ContextMenu("Load")]
    public void Load()
    {
        CharacterSaveData data = (CharacterSaveData) SaveManager.Load("charData");
        headUI.setPart(data.headIndex);
        bodyUI.setPart(data.bodyIndex);
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
