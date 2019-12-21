using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelectionContinue : MonoBehaviour
{
    public SaveDataAcrossScenes dataAcrossScenes;
    public characterCreationUI hairUI;
    public characterCreationUI headUI;
    public characterCreationUI bodyUI;
    public characterCreationUI portraitUI;
    public string characterName = "John";
    public int nextScene = 0;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        dataAcrossScenes = FindObjectOfType<SaveDataAcrossScenes>();
        //Debug.Log(dataAcrossScenes);
    }

    public void setName(string name)
    {
        characterName = name;
    }

    public void Complete()
    {
        //Save();
        //SaveToDataAcrossScene();
        SceneManager.LoadScene(nextScene);
    }

    [ContextMenu("Save")]
    public void Save()
    {
        CharacterSaveData data = new CharacterSaveData();

        data.CharacterName = characterName;
        data.headIndex = headUI.currentBodyPartIndex;
        data.bodyIndex = bodyUI.currentBodyPartIndex;
        SaveManager.Save(data,"charData");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        CharacterSaveData data = (CharacterSaveData) SaveManager.Load("charData");
        headUI.setPart(data.headIndex);
        bodyUI.setPart(data.bodyIndex);
    }

    void SaveToDataAcrossScene()
    {
        dataAcrossScenes.data.headIndex = headUI.currentBodyPartIndex;
        dataAcrossScenes.data.bodyIndex = headUI.currentBodyPartIndex;
        dataAcrossScenes.data.CharacterName = characterName;

        //Debug.Log(headUI.currentHead);
        //Debug.Log(headUI.currentHead);
        //Debug.Log(characterName);

    }
}
