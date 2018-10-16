using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReviewDemoAug : MonoBehaviour {

	public Text williamsText;

   // string williamsDoor;
   // string williamsCoax;

   // public EndOfDayReviewNote[] Notes;
    public DayDataHolder DayData;
   // string williamsDidntKnock;
	//string williamsBadIntro;
   // string williamsSecondAttempt;
  //  string williamsFirstAttempt;

  //  bool williamsDidntKnockBool;
  //  bool williamsBadIntroBool;
  //  bool williamsSecondAttemptBool;
  //  bool williamsFirstAttemptBool;

	public int pageNumber = 1;
	public GameObject backArrow;


    public ExampleVariableStorage variableStorage; //Link this later without public variabling it.
    //variableStorage.GetValue("$variable_name").AsBool
    public bool LoadData = false;
    void OnMouseDown()
	{
			print ("click");
			if (pageNumber < 3 && pageNumber > 0)
			{
				pageNumber++;
			}
	}

    void OnEnable()
    {
        //Mr. Williams door
        if (LoadData)
        {
            load();
        }
        williamsText.text = newReview();
        if (!LoadData)
            save();
    }
    public void load()
    {
        HospitalSaveData data = new HospitalSaveData();
        data =  (HospitalSaveData)SaveManager.Load();

        if(data != null)
        {
            data.Load(variableStorage);
        }
    }
    public void save()
    {
        HospitalSaveData data = new HospitalSaveData();
        foreach (EndOfDayReviewNote n in DayData.DecisionPoints)
        {
            foreach (string s in n.VariablesToEvaluate)
            {
                FlagData f = new FlagData(s, variableStorage.GetValue(s).AsBool);
                if(variableStorage.GetValue(s) == Yarn.Value.NULL)
                {
                    f.IsNull = true;
                }
                data.data.Add(f);

            }
        }
        foreach(string s in DayData.otherVariables)
        {
            FlagData f = new FlagData(s, variableStorage.GetValue(s).AsBool);
            if (variableStorage.GetValue(s) == Yarn.Value.NULL)
            {
                f.IsNull = true;
            }
            data.data.Add(f);
        }
        data.SceneName = SceneManager.GetActiveScene().name;
        SaveManager.Save(data);

    }
    string newReview()
    {
        string temp = "";
        foreach(EndOfDayReviewNote n in DayData.DecisionPoints)
        {
           
            bool b = false;
            bool isNull = false;

            if (n.Operation == EndOfDayReviewNote.OperationType.AND)
            {
                b = true;

                foreach (string s in n.VariablesToEvaluate)
                {
                    if ((variableStorage.GetValue(s).AsBool == false))
                    {
                        b = false;
                    }
                }

            }
              
            if (n.Operation == EndOfDayReviewNote.OperationType.OR)
            {
                b = false;
                foreach (string s in n.VariablesToEvaluate)
                {
                    if (variableStorage.GetValue(s) == Yarn.Value.NULL && b == false)
                    {
                        isNull = true;
                    }
                    if ((variableStorage.GetValue(s).AsBool == true))
                    {
                        b = true;
                        isNull = false;

                    }
                  
                }
            }
            if (isNull == false)
            {
               // Debug.Log(temp);

                if (b == true)
                {

                    temp += n.VariableTrue;
                }
                else
                {
                    temp += n.VariableFalse;


                }
            }
            else
            {

               // Debug.Log(n.VariablesToEvaluate[0] + " is null");
               // Debug.Log(temp);
            }
            
            
        }
    return temp;
    }
  

    void Update ()
    {
		if (pageNumber == 1 && williamsText.gameObject.activeInHierarchy == false)
        {
			williamsText.gameObject.SetActive(true);
		}
	}
}
