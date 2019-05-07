using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public Text RoomText;
    public Text DayText;
    public Text DayNumText;
    public Text MonthText;
    public Text TimeText;
    public Text AMorPMText;
    public Text ObjectiveText;

    public GameObject ClipboardUI;
    public GameObject EndofDayUI;
    public DayDataHolder dayData;

    public EoDClipboard EODClipboard;
    public DayManager dayManager;
    public ObjectiveLoader objectiveLoader;

	// Use this for initialization
	public void Setup (DayDataHolder day)
    {
        dayData = day;
        DayChange();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void GearClick()
    {
        if (EndofDayUI.activeInHierarchy == true)
        {
            EndofDayUI.SetActive(false);
        }
        else if (EndofDayUI.activeInHierarchy == false)
        {
            EndofDayUI.SetActive(true);
        }
    }

    public void ClipboardClick()
    {
        if (ClipboardUI.activeInHierarchy == true)
        {
            ClipboardUI.SetActive(false);
        }
        else if (ClipboardUI.activeInHierarchy == false)
        {
            ClipboardUI.SetActive(true);
        }
    }

    public void  DayChange()
    {
        DayText.text = dayData.DayOfTheWeek;
        DayNumText.text = dayData.DayNumber;
        MonthText.text = dayData.Month;
        TimeText.text = dayData.TimeOfDay;
        if(dayData.AMOrPM == false)
        {
            AMorPMText.text = "AM";
        }
        else
        {
            AMorPMText.text = "PM";
        }

    }


    public void LoadDay1()
    {
        dayManager.currentDay = 0;
        dayManager.LoadDay();
        EODClipboard.LoadEoDNotes(0);
    }

    public void LoadDay2()
    {
        dayManager.currentDay = 1;
        dayManager.LoadDay();
        EODClipboard.LoadEoDNotes(1);
    }

    public void LoadDay3()
    {
        dayManager.currentDay = 2;
        dayManager.LoadDay();
        EODClipboard.LoadEoDNotes(2);
    }

    public void LoadDay4()
    {
        dayManager.currentDay = 3;
        dayManager.LoadDay();
        EODClipboard.LoadEoDNotes(3);
    }

}
