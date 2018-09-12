using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public interface ISaveAble
{
    void Save(SaveData saveFile);
    void Load();
}
[System.Serializable]
public abstract class SaveData
{
    public SaveData()
    {

    }
    public abstract void Load();

}
public class SaveManager : MonoBehaviour {
    static List<ISaveAble> m_ObjectsToSave;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void DeleteSave(string filePath)
    {
        File.Delete(filePath);
    }

    //pass in apopriate savetata
    public static void Save(SaveData data, string saveName = "saveFile")
    {
       
        string fileName = "/" + saveName + ".dat";
      //  if (File.Exists(Application.persistentDataPath + fileName))
      //  {

       //     xmlUtils.Save(data, "/" + saveName + "1" + ".dat");
       // }
       // else
        {


            xmlUtils.Save(data, fileName);
        }
    }

    //pass in apopriate savetata
    // only loads new data 
    // caller is responsible for deleting old values 
    public static object Load( string saveName = "saveFile")
    {
        
        object data = xmlUtils.Load("/" + saveName +".dat");
        //for objects already in the scene (deletes them)
        /*  foreach (ISaveAble saveObjects in m_ObjectsToSave)
          {
              saveObjects.Load();
          }*/
        if (data == null)
        {
            Debug.Log("1 data is null");

        }
        return data;
      
    }
}
