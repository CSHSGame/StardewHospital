using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviewDemoAug : MonoBehaviour {

	public Text williamsText;

    string williamsDoor;
    string williamsCoax;



    string williamsDidntKnock;
	string williamsBadIntro;
    string williamsSecondAttempt;
    string williamsFirstAttempt;

    bool williamsDidntKnockBool;
    bool williamsBadIntroBool;
    bool williamsSecondAttemptBool;
    bool williamsFirstAttemptBool;

	public int pageNumber = 1;
	public GameObject backArrow;


    public ExampleVariableStorage variableStorage; //Link this later without public variabling it.
    //variableStorage.GetValue("$variable_name").AsBool

    void OnMouseDown()
		{
			print ("click");
			if (pageNumber < 3 && pageNumber > 0)
			{
				pageNumber++;
			}
		}

    void OnEnable()
    {
        //Mr. Williams door

        if (variableStorage.GetValue("$Knock_Wait_Williams").AsBool == true)
        {
            williamsDoor = "     Mr. Williams appreciated that you knocked before entering his room - it helps him to feel like this is his home, and that we respect his privacy. \n";
        }
        if (variableStorage.GetValue("$Knock_Barge_Williams").AsBool == true)
        {
            williamsDoor = "     Great that you remembered to knock on Mr. Williams door, but you need to wait for a response before you go barging in! Knocking isn't a formality - be sure you have a resident's consent before you enter their room. \n";
        }
        if (variableStorage.GetValue("$No_Knock_Williams").AsBool == true)
        {
            williamsDoor = "     You can't just go barging into Mr. William's room like that. Always knock and wait to be acknowledge before entering a client's room.";
        }
        //Mr. Williams
        if ((variableStorage.GetValue("$Sausage_Williams").AsBool == true) || (variableStorage.GetValue("$photo_Williams").AsBool == true))
        {
            williamsCoax = "     Although your first attempts to persuade him to eat weren't successful, you kept your cool when he lost his temper and found another way to approach the situation. Great work. \n \n I'm so glad that you two were able to bond in the end, it's really a remarkable turnaround from where you two were at yesterday.";
        }
        else
        {
            williamsCoax = "     Bringing Mr. Williams his breakfast was a great way to diffuse that situation, way to think on your feet. \n \n I'm so glad that you two were able to bond in the end, it's really a remarkable turnaround from where you two were at yesterday.  ";
        }

        williamsText.text = williamsDoor + williamsCoax;

    }

    /*void OnEnable()
    {
        //Mr. Martin
        //Did you knock?
        if (martinKnockedBool == true)
        {
            martinKnocked = "     Mr. Martin appreciated that you knocked before entering his room - it's important to remember that this is his home, and that we respect his privacy. ";
        }
        else
        {
            martinKnocked = "     Mr. Martin said you barged into his room without knocking - that's not acceptable. It's important to remember that this is his home, and that we respect the privacy of all our clients. ";
        } // if knocked bool is false end the assessment

        //Rude to mr. martin
        if (martinRudeBool == true)
        {
            martinRude = "\n     He didn't much care for the flippant tone with which you spoke to him. He's a very conservative person and you need to address him in a direct, professional manner. ";
        }
        else
        {
            martinRude = "\n     He said you spoke to him in a very polite and proffessional manner. He really appreciated that. ";
        }
        //Making plans with mr. martin
        if (martinCheckedWithSupervisorBool == true)
        {
            martinCheckedWithSupervisor = "\n     It's great that Mr. Martin offered to show you around! You should have some time free around 2pm tomorrow to take him up on his offer. ";
        }
        else
        {
            if (martinVagueBool == true)
            {
                martinCheckedWithSupervisor = "\n     It's great that Mr. Martin offered to show you around, but he really responds better to making definite plans at specific times. In this case, you should have said you would check in with me for an appropriate time and then let him know. ";
            }
            else
            {
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
        if (youssafRudeBool == true && youssafLeavesBool == false)
        {
            youssafText.text = "     You were quite rude with Mr. Youssaf, especially considering you were told not be confrontational with him. You could have done better to diffuse that situation. ";
        }

        if (youssafRudeBool == false && youssafLeavesBool == false)
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

    */

    void Update () {
		if (pageNumber == 1){
			williamsText.gameObject.SetActive(true);
		}
	}
}
