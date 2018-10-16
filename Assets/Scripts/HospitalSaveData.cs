using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HospitalSaveData : SaveData
{
    public string SceneName;
    public List<FlagData> data;
    public HospitalSaveData()
    {
        data = new List<FlagData>();
    }

    public void Load(ExampleVariableStorage storage)
    {
        Debug.Log("LOADING TEST");

       foreach(FlagData f in data)
       {
            if(f.IsNull == false)
            { 
                storage.SetValue(f.VariableName, new Yarn.Value(f.Value));
            }
            
       }
       // throw new System.NotImplementedException();
    }

    public override void Load()
    {
       // throw new System.NotImplementedException();
    }


}
[System.Serializable]
public class FlagData
{
    public FlagData(string name, bool val)
    {
        VariableName = name;
        Value = val;
    }
    public string VariableName;
    public bool Value;
    public bool IsNull;

}


