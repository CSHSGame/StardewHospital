using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clipboard : MonoBehaviour {

    public Button[] FacesButtons;
    public NPCClipboardData[] clipboardData;
    public Sprite[] ClipboardTabs;

    public Text NameText;
    public Text LocationText;
    public Text AgeText;
    public Text GenderText;
    public Text ResidentNumText;
    public Text AlergiesText;
    public Text PowerOfAttorneyText;
    public Text POAPhoneNumText;
    public Text NextOfKinText;
    public Text HealthStatusText;
    public Text CodeStatusText;
    public Text LanguageSpokenText;
    public Text ReligionText;


    private Image clipboardSprite;
    private int currentResident;

    // public Text Name1;
    // public Text Name2;
    // public Text Name3;
    // public Text Name4;
    // public Text Name5;

    // public Image Face1;
    // public Image Face2;
    // public Image Face3;
    // public Image Face4;
    // public Image Face5;


    // Use this for initialization
    void Start () {

        clipboardSprite = GetComponent<Image>();

        ResidentInfo(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ResidentInfo(int index)
    {
        NameText.text = clipboardData[index].Charname;
        LocationText.text = clipboardData[index].Location;
        AgeText.text = clipboardData[index].Age.ToString();
        GenderText.text = clipboardData[index].charGender.ToString();
        ResidentNumText.text = clipboardData[index].ResidentNum.ToString();
        AlergiesText.text = clipboardData[index].Allergies;
        PowerOfAttorneyText.text = clipboardData[index].PowerOfAttorney;
        POAPhoneNumText.text = clipboardData[index].POAPhoneNum;
        NextOfKinText.text = clipboardData[index].NextOfKin;
        HealthStatusText.text = clipboardData[index].HealthStatus;
        CodeStatusText.text = clipboardData[index].CodeStatus;
        LanguageSpokenText.text = clipboardData[index].LanguageSpoken;
        ReligionText.text = clipboardData[index].Religion;
       
        clipboardSprite.sprite = ClipboardTabs[index];

    }
   
}
