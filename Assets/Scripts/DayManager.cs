using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yarn.Unity;
using Yarn.Unity.Example;

public class DayManager : MonoBehaviour
{
    NpcLoader npcLoader;
    ObjectiveLoader objectiveLoader;
    HUDController hUDController;
    public EoDClipboard EoDClipboard;
    public DayDataHolder[] Days;
    public int currentDay = 0;
    ExampleVariableStorage variableStorage;
    public Text display;

    public NpcDayData PlayerToWalkOutData;
    public float debugTimeScale = 5;
    // Use this for initialization
    void Start ()
    {
        Time.timeScale = debugTimeScale;
        variableStorage = FindObjectOfType<ExampleVariableStorage>();
        hUDController = FindObjectOfType<HUDController>();
        npcLoader = GetComponent<NpcLoader>();
        objectiveLoader = GetComponent<ObjectiveLoader>();
       

        npcLoader.Setup(Days[currentDay]);
        objectiveLoader.Setup(Days[currentDay].Objectives);
        hUDController.Setup(Days[currentDay],currentDay);
        StartCoroutine(showDayText());
    }
    //should only be called from the clipboard closing
    public void LoadDay()
    {
        Debug.Log(currentDay);
        if(PlayerToWalkOutData != null)
        {
            CinematicMode cinematic = FindObjectOfType<CinematicMode>(); ;
           
            Waypoints player = GameObject.FindObjectOfType<PlayerCharacter>().GetComponent<Waypoints>();
            player.data = PlayerToWalkOutData;
            player.loadData();
            player.transform.position = new Vector3(5.2f, 0.13f, 6.8f);
            player.onPathDone.RemoveAllListeners();
            player.onPathDone.AddListener
            (() =>
                {
                    Debug.Log("-------fireing onPathDone changing day-----");
                    cinematic.TurnOFF();
                    npcLoader.DeleteNpc();
                    npcLoader.Setup(Days[currentDay]);
                    objectiveLoader.Setup(Days[currentDay].Objectives);
                    hUDController.Setup(Days[currentDay], currentDay);
                    StartCoroutine(showDayText());
                }
            );
            cinematic.TurnON();
            player.StartPathing("Zero");



        }
        else
        {
            npcLoader.DeleteNpc();
            npcLoader.Setup(Days[currentDay]);
            objectiveLoader.Setup(Days[currentDay].Objectives);
            hUDController.Setup(Days[currentDay], currentDay);
            StartCoroutine(showDayText());
        }
       

       
    }

    public IEnumerator showDayText()
    {
        FadeMode fader =  FindObjectOfType<FadeMode>();

        if (fader != null)
        {
            fader.FadeOn();
            if (fader.msgText != null)
            {
                fader.msgText.text = Days[currentDay].name;
                fader.msgText.enabled = true;
            }

            yield return new WaitForSecondsRealtime(2f);
            if (fader.msgText != null)
            { 

                fader.msgText.enabled = false;
            }
            fader.FadeOff();

        }

        yield return null;
    }

    [YarnCommand("PrepForNextDay")]
    public void SetupForLastPathofDay()
    {
        CinematicMode cinematic = FindObjectOfType<CinematicMode>(); ;
        cinematic.TurnON();
        Waypoints player = GameObject.FindObjectOfType<PlayerCharacter>().GetComponent<Waypoints>();
        player.onPathDone.AddListener
        (() =>
            {
                currentDay++;
                cinematic.TurnOFF();

                EoDClipboard.gameObject.SetActive(true);
                //hUDController.GearClick();
            }
        );


        //LoadDay();
    }
    [YarnCommand("NextDay")]
    public void IncrementDay()
    {
        currentDay++;
        EoDClipboard.gameObject.SetActive(true);
        //hUDController.GearClick();
        //LoadDay();
    }
    [YarnCommand("Reset")]
    public void resetDay()
    {
        EoDClipboard.gameObject.SetActive(true);
        //hUDController.GearClick();

        // SceneManager.LoadScene(0);
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
        //SceneManager.LoadScene(2);
        EoDClipboard.gameObject.SetActive(true);
        //hUDController.GearClick();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
