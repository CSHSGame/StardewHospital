using UnityEngine;
using System;
// allows us to write out binary files that are not encrypted but they are unreadable i.e. in binary
using System.Runtime.Serialization.Formatters.Binary;
// allows input/output to files
using System.IO;
using System.Collections;

using System.Collections.Generic;

public class xmlUtils : MonoBehaviour
{

    public static int test = 5;
    void Start()
    {
        print("data Loaded");
    }
    public static void Save(object obj, string fileName = "/PersistentTest.dat")
    {
        // create a file... binary formatter writes for us
        BinaryFormatter bf = new BinaryFormatter();
        // creating the file and attempting to open it
        FileStream file = File.Create(Application.persistentDataPath + fileName);
        // we need a clean serializable class (object) that can just contain or mirror our data...
        // ...instantiating such a class as we have below
        //MemoryStream memoryStream = new MemoryStream();
        bf.Serialize(file, obj);

    }
    public static List<string> getSaveFileNames()
    {
        List<String> myList = new List<string>();
        foreach (string file in System.IO.Directory.GetFiles(Application.persistentDataPath))
        {
            
            myList.Add(file);
        }
        return myList;
    }
   
    public static object Load(string fileName = "/PersistentTest.dat")
    {

        if (File.Exists(Application.persistentDataPath + fileName))
        {
          //  Debug.Log("file exist");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
            // have to cast this object to what we want it to be as bf pulls it but does not know what kind of obj it is
            object data = (object)bf.Deserialize(file);
            file.Close();
            return data;
        }
       // Debug.Log("file does not exist");
        Debug.Log(fileName);
        return null;
    }
}
