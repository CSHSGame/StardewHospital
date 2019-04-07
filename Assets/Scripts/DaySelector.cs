using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DaySelector : MonoBehaviour {

    public Button[] DayButtons;

    public GameObject DebugCanvas;

    private void Start()
    {
        DayButtonSetup();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DebugCanvas.SetActive(!DebugCanvas.activeInHierarchy);
        }
    }


    void DayButtonSetup()
    {
        for (int i = 0; i < DayButtons.Length; i++)
        {
            int capIterator = i;
            DayButtons[i].onClick.AddListener(() => RunDay(capIterator));
        }
    }

    public void RunDay(int dayindex)
    {
        switch(dayindex)
        {
            case 0:
                SceneManager.LoadScene("Day 1");
                break;
            case 1:
                SceneManager.LoadScene("Day 2");
                break;
            case 2:
                SceneManager.LoadScene("Day 3");
                break;
            case 3:
                SceneManager.LoadScene("Day 4");
                break;
            case 4:
                SceneManager.LoadScene("Day 5");
                break;
            case 5:
                SceneManager.LoadScene("Day 6");
                break;
            case 6:
                SceneManager.LoadScene("Day 7");
                break;
            case 7:
                SceneManager.LoadScene("Day 8");
                break;
            case 8:
                SceneManager.LoadScene("Day 9");
                break;
            case 9:
                SceneManager.LoadScene("Day 10");
                break;
            case 10:
                SceneManager.LoadScene("Day 11");
                break;
            case 11:
                SceneManager.LoadScene("Day 12");
                break;
            case 12:
                SceneManager.LoadScene("Day 13");
                break;
            case 13:
                SceneManager.LoadScene("Day 14");
                break;
            default:
                break;
        }




    }
}