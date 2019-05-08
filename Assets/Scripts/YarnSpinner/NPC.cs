/*

The MIT License (MIT)

Copyright (c) 2015-2017 Secret Lab Pty. Ltd. and Yarn Spinner contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using UnityEngine;

using System.Collections;
using UnityEngine.Serialization;
/// attached to the non-player characters, and stores the name of the
/// Yarn node that should be run when you talk to them.
namespace Yarn.Unity.Example
{
    public class NPC : MonoBehaviour
    {
        Waypoints movement;
        [YarnCommand("DeSpawn")]
        public void turnInvisible()
        {
        
                movement.onPathDone.AddListener(() => 
                {
                    turnInvisibleDelegate();
                    movement.onPathDone.RemoveAllListeners();

                });
            
        }
        [YarnCommand("Hide")]
        public void Hide()
        {
            turnInvisibleDelegate();



        }

        private void turnInvisibleDelegate()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            this.enabled = false; ;
        }
        [YarnCommand("Spawn")]
        public void turnVisible()
        {
            transform.GetChild(0).gameObject.SetActive(true);
            this.enabled = true;
        }
        private enum Characters
        {
            Martin,
            MartinDoor,
            Williams,
            WilliamsDoor,
            Yousaf,
            Stein,
            Secretary,
            NurseManager,
        }
        //private Characters thisCharacter;

        //public NpcController aiController;

      //  public ExampleVariableStorage variableStorage; //Link this later without public variabling it.

        //public FadeObjectInOut roomShade;

        public GameObject ConversUI;

        //public string characterName = "";

        [FormerlySerializedAs("startNode")]
        public string talkToNode = "";

        [Header("Optional")]
        public TextAsset scriptToLoad;

        public NpcDayData data;
        [YarnCommand("SetDialog")]
        public void SettingDialog(string NodeName)
        {
            Debug.Log("called " + NodeName);
            talkToNode = NodeName;

        }




        // Use this for initialization
        void Start ()
        {
            if (scriptToLoad != null)
            {
                FindObjectOfType<Yarn.Unity.DialogueRunner>().AddScript(scriptToLoad);
            }

            if (scriptToLoad != null)
            {
                //ConversUI = GameObject.Find("sprite/SpaceBar");    
            }
            movement = GetComponent<Waypoints>();
        }

        // Update is called once per frame
        void Update ()
        {

           
        }

        public void OnConversationStart()
        {
            //if(aiController != null)
              //  aiController.isTalking = true;
        }
        
        public void ICanConverse(bool inRange)
        {
           
            if (inRange)
            {
                if (FindObjectOfType<DialogueRunner>().isDialogueRunning == false)
                {
                 //   Debug.Log("inRange");
                    if (ConversUI != null)
                    {
                        ConversUI.gameObject.SetActive(true);
                       // Debug.Log("ConverseUI");
                    }
                }
                else
                {
                    if (ConversUI != null)
                    {
                        this.ConversUI.gameObject.SetActive(false);
                      //  Debug.Log("NoConverseUI");
                    }
                }
            }
            else
            {
                this.ConversUI.gameObject.SetActive(false);
                //Debug.Log("NoConverseUI");
            }
        }
        public void BakeData()
        {
            data.position = transform.position;
            data.rotation = transform.rotation;
            data.scale = transform.localScale;
            data.talkToNode = talkToNode;
            data.scriptToLoad = scriptToLoad;
            data.GameObjectName = this.gameObject.name;
           
            data.sprite = this.GetComponentInChildren<SpriteRenderer> ().sprite;
           // data.prefab = test;

        }

        public void LoadData()
        {
            transform.position =  data.position ;
            transform.rotation = data.rotation ;
            transform.localScale =  data.scale  ;
            talkToNode= data.talkToNode  ;
            scriptToLoad = data.scriptToLoad  ;

            gameObject.name = data.GameObjectName;
           
            GetComponentInChildren<SpriteRenderer>().sprite = data.sprite;
            GetComponentInChildren<SpriteRenderer>().gameObject.AddComponent<BoxCollider>();
            NpcAnimController npcAnim = GetComponentInChildren<NpcAnimController>();
         //   Waypoints wp = GetComponent<Waypoints>();
            //wp.Setup();
            if (data.AnimatorController != null && npcAnim)
            {
                //Debug.Log("fdfffffffff");
                npcAnim.test = data.AnimatorController;
                npcAnim.Setup();
            }
            if (data.visibleAtStart == false)
            {
                turnInvisibleDelegate();
            }
         
        }
    }
   
}
