using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class EoDClipboardData : ScriptableObject
{


    public string DP1Evaluate;
    public string DP2Evaluate;
    public string DP3Evaluate;

    public bool DP1Outcome1TrueOutcome2False;
    public bool DP2Outcome1TrueOutcome2False;
    public bool DP3Outcome1TrueOutcome2False;

    public string DecisionPoint1Outcome1Title;
    [TextArea]
    public string DecisionPoint1Outcome1Text;
    public string DecisionPoint2Outcome1Title;
    [TextArea]
    public string DecisionPoint2Outcome1Text;
    public string DecisionPoint3Outcome1Title;
    [TextArea]
    public string DecisionPoint3Outcome1Text;


    public string DecisionPoint1Outcome2Title;
    [TextArea]
    public string DecisionPoint1Outcome2Text;
    public string DecisionPoint2Outcome2Title;
    [TextArea]
    public string DecisionPoint2Outcome2Text;
    public string DecisionPoint3Outcome2Title;
    [TextArea]
    public string DecisionPoint3Outcome2Text;



    public string LearningObjectives1Title;
    [TextArea]
    public string LearningObjectives1Text;
    public string LearningObjectives2Title;
    [TextArea]
    public string LearningObjectives2Text;
    public string LearningObjectives3Title;
    [TextArea]
    public string LearningObjectives3Text;




    public string BestPractices1Title;
    [TextArea]
    public string BestPractices1Text;
    public string BestPractices2Title;
    [TextArea]
    public string BestPractices2Text;
    public string BestPractices3Title;
    [TextArea]
    public string BestPractices3Text;

}