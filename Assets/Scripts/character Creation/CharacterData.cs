using System;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    //saved as tramnform since different sprites have different pivot points 
    public Transform[] Bodies;
    public Transform[] heads;
    public string characterName;

}

[System.Serializable]
public class CharacterSaveData : SaveData
{
    public string CharacterName;
    public int headIndex;
    public int bodyIndex;
    public Transform[] Bodies;
    public Transform[] heads;

    public override void Load()
    {
        //throw new NotImplementedException();
    }
}
