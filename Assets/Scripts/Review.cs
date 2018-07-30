using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Review : MonoBehaviour {

	public Text martinText;
	public Text steinText;
	public Text youssafText;

	string martinKnocked;
	string martinRude;
	string martinVague;
	string martinCheckedWithSupervisor;

	string youssafRude;
	string youssafLeaves;

	string steinTooSoon;
	string steinTooPushy;
	string steinGood;

	public bool martinKnockedBool;
	public bool martinRudeBool;
	public bool martinVagueBool;
	public bool martinCheckedWithSupervisorBool;

	public bool youssafRudeBool;
	public bool youssafLeavesBool;

	public bool steinTooSoonBool;
	public bool steinTooPushyBool;
	public bool steinGoodBool;

	public int pageNumber = 1;
	public GameObject backArrow;



	void OnMouseDown()
		{
			print ("click");
			if (pageNumber < 3 && pageNumber > 0)
			{
				pageNumber++;
			}
		}
	
	void OnEnable () {
//Mr. Martin
	//Did you knock?
		if (martinKnockedBool == true) {
			martinKnocked = "     Mr. Martin appreciated that you knocked before entering his room - it's important to remember that this is his home, and that we respect his privacy. ";
		}else{
			martinKnocked = "     Mr. Martin said you barged into his room without knocking - that's not acceptable. It's important to remember that this is his home, and that we respect the privacy of all our clients. ";
		} // if knocked bool is false end the assessment

	//Rude to mr. martin
		if (martinRudeBool == true) {
			martinRude = "\n     He didn't much care for the flippant tone with which you spoke to him. He's a very conservative person and you need to address him in a direct, professional manner. ";
		}else{
			martinRude = "\n     He said you spoke to him in a very polite and proffessional manner. He really appreciated that. ";
		}
	//Making plans with mr. martin
		if (martinCheckedWithSupervisorBool == true)
		{
			martinCheckedWithSupervisor = "\n     It's great that Mr. Martin offered to show you around! You should have some time free around 2pm tomorrow to take him up on his offer. ";
		}else{
			if (martinVagueBool == true)
			{
				martinCheckedWithSupervisor = "\n     It's great that Mr. Martin offered to show you around, but he really responds better to making definite plans at specific times. In this case, you should have said you would check in with me for an appropriate time and then let him know. ";
			} else {
				martinCheckedWithSupervisor = "\n     It's great that Mr. Martin offered to show you around, but I had other plans for you tomorrow at that time! Next time please check in with me first.";
			}
		}
			martinText.text = martinKnocked + martinRude + martinCheckedWithSupervisor;

//Mr.Youssaf
	
		//Mr Youssaf Leaves
		if (youssafLeavesBool == true) 
		{
			youssafText.text = "     You allowed Mr. Youssaf to just leave?? Have you lost your mind?? Lucky for you security caught up with him at the gate, otherwise we'd be looking at a major lawsuit. Unbelievable... ";
		}

		//Rude to Mr Youssaf
		if(youssafRudeBool == true && youssafLeavesBool == false)
		{
			youssafText.text = "     You were quite rude with Mr. Youssaf, especially considering you were told not be confrontational with him. You could have done better to diffuse that situation. ";
		}

		if(youssafRudeBool == false && youssafLeavesBool == false)
		{
			youssafText.text = "     I'm so impressed by the way you handled that situation with Mr. Youssaf - you made sure not to come off as confrontational and as a result diffused a situation that could have quickly escalated. Great work! ";
		}

// Mrs Stein
		//Mrs Stein Fail
		if (steinTooSoonBool == true)
		{
			steinText.text = "     Mrs. Stein was quite upset with you today. You were just supposed to stop by and introduce yourself - what in the world made you hink it would be appropriate to bring up her health? Especially after being informed that it was a sensitive topic. We expect a little more thoughtfulness and empathy from you moving forward. ";
		}
		//Mrs Stein too pushy		
		if (steinTooPushyBool == true)
		{
			steinText.text = "     Mrs Stein enjoyed meeting you, but you'll need to show a little more discretion in the future. Revealing that the secretary had informed you of her illness before you'd even met made her feel a little uncomfortable.";
		}
		//Mrs Stein Success
		if (steinGoodBool == true)
		{
			steinText.text = "     You made a great first impression on Mrs Stein and did a great job of being empathetic without pushing or prying too much. ";
		}
	}

	
	
	void Update () {
		if (pageNumber == 1){
			martinText.gameObject.SetActive(true);
			youssafText.gameObject.SetActive(false);
			steinText.gameObject.SetActive(false);
			backArrow.SetActive(false);		
		}

		if (pageNumber == 2){
			martinText.gameObject.SetActive(false);
			youssafText.gameObject.SetActive(true);
			steinText.gameObject.SetActive(false);
			backArrow.SetActive(true);
		}

		if (pageNumber == 3){
			martinText.gameObject.SetActive(false);
			youssafText.gameObject.SetActive(false);
			steinText.gameObject.SetActive(true);
		}
	}
}
