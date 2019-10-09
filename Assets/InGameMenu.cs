using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    public Button DaySelectionButton;
    public Button ControlsButton;
    public Button CreditsButton;
    public Button BackToMainMenuButton;
    public Button QuitGameButton;

    public GameObject DaySelectionMenu;
    public GameObject ControlsMenu;
    public GameObject CreditsMenu;
    public GameObject ButtonMenu;

    public EoDClipboard EODClipboard;
    public DayManager dayManager;

    public void GoToButtonMenu()
    {
        if (ButtonMenu.activeInHierarchy == true)
        {
            ButtonMenu.SetActive(false);
        }
        else if (ButtonMenu.activeInHierarchy == false)
        {
            ButtonMenu.SetActive(true);
        }
    }


    public void GoToDaySelection()
    {
        if (DaySelectionMenu.activeInHierarchy == true)
        {
            DaySelectionMenu.SetActive(false);
        }
        else if (DaySelectionMenu.activeInHierarchy == false)
        {
            DaySelectionMenu.SetActive(true);
        }
    }

    public void LoadDay(int dayIndex)
    {
        dayManager.currentDay = dayIndex;
        dayManager.LoadDay();
        EODClipboard.DayIndex = dayIndex;
        EODClipboard.LoadEoDNotes(dayIndex);
    }

    public void GoToControls()
    {
        if (ControlsMenu.activeInHierarchy == true)
        {
            ControlsMenu.SetActive(false);
        }
        else if (ControlsMenu.activeInHierarchy == false)
        {
            ControlsMenu.SetActive(true);
        }
    }

    public void GoToCredits()
    {
        if (CreditsMenu.activeInHierarchy == true)
        {
            CreditsMenu.SetActive(false);
        }
        else if (CreditsMenu.activeInHierarchy == false)
        {
            CreditsMenu.SetActive(true);
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
