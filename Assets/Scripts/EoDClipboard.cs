using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EoDClipboard : MonoBehaviour {


    public Button[] TabsButtons;
    public EoDClipboardData[] EoDClipboardData;
    public Text Title1;
    public Text Text1;
    public Text Title2;
    public Text Text2;
    public Text Title3;
    public Text Text3;

    //Decision Points Outcomes
    private bool DP1Outcome1TrueOutcome2False;
    private bool DP2Outcome1TrueOutcome2False;
    private bool DP3Outcome1TrueOutcome2False;

    //Decision Point # Choice 1 Header or Text
    private string DP1C1H;
    private string DP1C1T;
    private string DP2C1H;
    private string DP2C1T;
    private string DP3C1H;
    private string DP3C1T;

    //Decision Point # Choice 2 Header or Text
    private string DP1C2H;
    private string DP1C2T;
    private string DP2C2H;
    private string DP2C2T;
    private string DP3C2H;
    private string DP3C2T;

    //Learning Objectives # Header or Text
    private string LO1H;
    private string LO1T;
    private string LO2H;
    private string LO2T;
    private string LO3H;
    private string LO3T;

    //Best Practices # Header or Text
    private string BP1H;
    private string BP1T;
    private string BP2H;
    private string BP2T;
    private string BP3H;
    private string BP3T;




    // Use this for initialization
    void Start () {
        LoadEoDNotes(0);
        DecisionPointButtonPress();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadEoDNotes(int index)
    {

        //Decision Point Outcome
        DP1Outcome1TrueOutcome2False = EoDClipboardData[index].DP1Outcome1TrueOutcome2False;
        DP2Outcome1TrueOutcome2False = EoDClipboardData[index].DP2Outcome1TrueOutcome2False;
        DP3Outcome1TrueOutcome2False = EoDClipboardData[index].DP3Outcome1TrueOutcome2False;

        // Decision Point DataStoring
        DP1C1H = EoDClipboardData[index].DecisionPoint1Outcome1Title;
        DP1C1T = EoDClipboardData[index].DecisionPoint1Outcome1Text;
        DP2C1H = EoDClipboardData[index].DecisionPoint2Outcome1Title;
        DP2C1T = EoDClipboardData[index].DecisionPoint2Outcome1Text;
        DP3C1H = EoDClipboardData[index].DecisionPoint3Outcome1Title;
        DP3C1T = EoDClipboardData[index].DecisionPoint3Outcome1Text;

        DP1C2H = EoDClipboardData[index].DecisionPoint1Outcome2Title;
        DP1C2T = EoDClipboardData[index].DecisionPoint1Outcome2Text;
        DP2C2H = EoDClipboardData[index].DecisionPoint2Outcome2Title;
        DP2C2T = EoDClipboardData[index].DecisionPoint2Outcome2Text;
        DP3C2H = EoDClipboardData[index].DecisionPoint3Outcome2Title;
        DP3C2T = EoDClipboardData[index].DecisionPoint3Outcome2Text;

        //Learning Objectives Data Storing
        LO1H = EoDClipboardData[index].LearningObjectives1Title;
        LO1T = EoDClipboardData[index].LearningObjectives1Text;
        LO2H = EoDClipboardData[index].LearningObjectives2Title;
        LO2T = EoDClipboardData[index].LearningObjectives2Text;
        LO3H = EoDClipboardData[index].LearningObjectives3Title;
        LO3T = EoDClipboardData[index].LearningObjectives3Text;


        //Best Practices Data Storing
        BP1H = EoDClipboardData[index].BestPractices1Title;
        BP1T = EoDClipboardData[index].BestPractices1Text;
        BP2H = EoDClipboardData[index].BestPractices2Title;
        BP2T = EoDClipboardData[index].BestPractices2Text;
        BP3H = EoDClipboardData[index].BestPractices3Title;
        BP3T = EoDClipboardData[index].BestPractices3Text;

    }

    public void DecisionPointButtonPress()
    {
        if (DP1Outcome1TrueOutcome2False)
        {
            Title1.text = DP1C1H;
            Text1.text = DP1C1T;
        }
        else
        {
            Title1.text = DP1C2H;
            Text1.text = DP1C2T;
        }

        if (DP2Outcome1TrueOutcome2False)
        {
            Title2.text = DP2C1H;
            Text2.text = DP2C1T;
        }
        else
        {
            Title2.text = DP2C2H;
            Text2.text = DP2C2T;
        }

        if(DP3Outcome1TrueOutcome2False)
        {
            Title3.text = DP3C1H;
            Text3.text = DP3C1T;
        }
        else
        {
            Title3.text = DP3C2H;
            Text3.text = DP3C2T;
        }
    }

    public void LearningObjectivesButtonPressed()
    {
        Title1.text = LO1H;
        Text1.text = LO1T;
        Title2.text = LO2H;
        Text2.text = LO2T;
        Title3.text = LO3H;
        Text3.text = LO3T;
    }

    public void BestPracticesButtonPressed()
    {
        Title1.text = BP1H;
        Text1.text = BP1T;
        Title2.text = BP2H;
        Text2.text = BP2T;
        Title3.text = BP3H;
        Text3.text = BP3T;
    }
}
