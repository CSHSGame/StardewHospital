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

    public GameObject ClipboardUI;
    public GameObject EndofDayUI;
    public DayDataHolder dayData;

    public DayManager dayManager;

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
        dayManager.currentDay = 1;
        dayManager.LoadDay();
    }

    public void LoadDay2()
    {
        dayManager.currentDay = 2;
        dayManager.LoadDay();
    }

    public void LoadDay3()
    {
        dayManager.currentDay = 3;
        dayManager.LoadDay();
    }


}
