using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clipboard : MonoBehaviour {

    public Button[] FacesButtons;

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

    public NPCClipboardData[] clipboardData;

    public int patientData = 0;
	// Use this for initialization
	void Start () {
        FillClipboardInfo();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FillClipboardInfo()
    {
        NameText.text = clipboardData[patientData].Charname;
        LocationText.text = clipboardData[patientData].Location;
        AgeText.text = clipboardData[patientData].Age.ToString();
        GenderText.text = clipboardData[patientData].charGender.ToString();
        ResidentNumText.text = clipboardData[patientData].ResidentNum.ToString();
        AlergiesText.text = clipboardData[patientData].Allergies;
        PowerOfAttorneyText.text = clipboardData[patientData].PowerOfAttorney;
        POAPhoneNumText.text = clipboardData[patientData].POAPhoneNum;
        NextOfKinText.text = clipboardData[patientData].NextOfKin;
        HealthStatusText.text = clipboardData[patientData].HealthStatus;
        CodeStatusText.text = clipboardData[patientData].CodeStatus;
        LanguageSpokenText.text = clipboardData[patientData].LanguageSpoken;
        ReligionText.text = clipboardData[patientData].Religion; 
    }
}
