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
    HUDController hUDController;
    public DayDataHolder[] Days;
    public int currentDay = 0;
    ExampleVariableStorage variableStorage;
    public Text display; 
    // Use this for initialization
    void Start ()
    {
        variableStorage = FindObjectOfType<ExampleVariableStorage>();
        hUDController = FindObjectOfType<HUDController>();
        npcLoader = GetComponent<NpcLoader>();
        objectiveLoader = GetComponent<ObjectiveLoader>();

        npcLoader.Setup(Days[currentDay]);
        objectiveLoader.Setup(Days[currentDay].Objectives);
        hUDController.Setup(Days[currentDay]);
        StartCoroutine(showDayText());
    }
    public void LoadDay()
    {
        npcLoader.DeleteNpc();
        npcLoader.Setup(Days[currentDay]);
        objectiveLoader.Setup(Days[currentDay].Objectives);
        hUDController.Setup(Days[currentDay]);
        StartCoroutine(showDayText());
    }

    public IEnumerator showDayText()
    {
        FadeMode fader =  FindObjectOfType<FadeMode>();
        if(fader != null)
        {
            fader.FadeOn();
            fader.msgText.text = Days[currentDay].name;
            fader.msgText.enabled = true;
            yield return new WaitForSecondsRealtime(2f);
            fader.msgText.enabled = false;

            fader.FadeOff();

        }

        yield return null;
    }
    [YarnCommand("NextDay")]
    public void IncrementDay()
    {
        currentDay++;
        LoadDay();
    }
    [YarnCommand("Reset")]
    public void resetDay()
    {
        SceneManager.LoadScene(0);
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
