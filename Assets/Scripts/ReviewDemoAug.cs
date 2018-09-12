using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        data =  (HospitalSaveData)SaveManager.Load("saveTest");

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
                data.data.Add(new FlagData(s, variableStorage.GetValue(s).AsBool));
            }
        }
        foreach(string s in DayData.otherVariables)
        {
            data.data.Add(new FlagData(s, variableStorage.GetValue(s).AsBool));

        }
        data.CurrentDay = DayData.CurrentDay;
        SaveManager.Save(data,"saveTest");

    }
    string newReview()
    {
        string temp = "";
        foreach(EndOfDayReviewNote n in DayData.DecisionPoints)
        {
           
            bool b = false;

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

                    if ((variableStorage.GetValue(s).AsBool == true))
                    {
                        b = true;
                    }
                }
            }
            if (b)
            {
                temp += n.VariableTrue;
            }
            else
            {
                temp += n.VariableFalse;


            }

        }
    return temp;
    }
  

    void Update () {
		if (pageNumber == 1 && williamsText.gameObject.activeInHierarchy == false)
        {
			williamsText.gameObject.SetActive(true);
		}
	}
}
