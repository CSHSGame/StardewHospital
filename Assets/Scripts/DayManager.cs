using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class DayManager : MonoBehaviour
{
    NpcLoader npcLoader;
    ObjectiveLoader objectiveLoader;
    public DayDataHolder[] Days;
    public int currentDay = 0;
    ExampleVariableStorage variableStorage;
    public Text display; 
    // Use this for initialization
    void Start ()
    {
        variableStorage = FindObjectOfType<ExampleVariableStorage>();
        npcLoader = GetComponent<NpcLoader>();
        objectiveLoader = GetComponent<ObjectiveLoader>();

        npcLoader.Setup(Days[currentDay]);
        objectiveLoader.Setup(Days[currentDay].Objectives);
    }
    void LoadDay()
    {
        npcLoader.DeleteNpc();
        npcLoader.Setup(Days[currentDay]);
        objectiveLoader.Setup(Days[currentDay].Objectives);
    }
	[ContextMenu("changeDay")]
    public void IncrementDay()
    {
        currentDay++;
        LoadDay();
    }
    [ContextMenu("testReview")]
    string newReview()
    {
        string temp = "";
        foreach (EndOfDayReviewNote n in Days[currentDay].DecisionPoints)
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
        display.text = temp;
        return temp;
    }
    [YarnCommand("FinishIt")]
    public void endGame()
    {
        SceneManager.LoadScene(2);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
