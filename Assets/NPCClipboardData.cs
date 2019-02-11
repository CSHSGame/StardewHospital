using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class NPCClipboardData : ScriptableObject {

    public string Charname;
    public string Location;
    public int Age;
    public enum Gender { Male,Female, AttackHelicopter, Other };
    public Gender charGender;
    public int ResidentNum;
    public string Allergies;
    public string PowerOfAttorney;
    public string POAPhoneNum;
    public string NextOfKin;
    public string HealthStatus;
    public string CodeStatus;
    public string LanguageSpoken;
    public string Religion;


	
}
