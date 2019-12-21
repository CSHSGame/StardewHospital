using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataAcrossScenes : MonoBehaviour {

    public CharacterSelectionContinue characterSelectionContinue;
    public CharacterSaveData data;
    public CharacterLoad charLoad;
    public CharacterController charController;
    public SpriteDepthSwapper spriteDepthSwapper;
    public bool loadCharacter = true;

    public int hairIndex; // 0 is redhair, 1 is blond, 2 is hijab, 3 is curly, 4 is buzzed, 5 is turban
    public int headIndex; // 0 is female, 1 is male
    public int bodyIndex; // 0 is female, 1 is male
    public int portraitIndex; 

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Use this for initialization
    void Start () {
       


       
	}

    private void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if(scene.buildIndex == 2)
        {
            charLoad = FindObjectOfType<CharacterLoad>();
            charController = FindObjectOfType<CharacterController>();
            spriteDepthSwapper = FindObjectOfType<SpriteDepthSwapper>();
        }
        

    }
    // Update is called once per frame
    void Update ()
    {
        if (charLoad != null)
        {
            if(loadCharacter)
            {
                ////charLoad.Assets.heads[0] = data.headIndex;
                //charLoad.Assets.Bodies[data.bodyIndex] = data.Bodies[data.bodyIndex];
                //Debug.Log(charLoad.Assets.Bodies[data.bodyIndex]);
                //for (int i = 0; i < charLoad.transform.childCount; i++)
                //{
                //    Destroy(charLoad.transform.GetChild(i).gameObject);
                //}
                //Instantiate(charLoad.Assets.heads[data.headIndex], charLoad.transform);
                //Instantiate(charLoad.Assets.Bodies[data.bodyIndex], charLoad.transform);

                //charController.bodyPartBody = charLoad.Assets.Bodies[data.bodyIndex].gameObject.GetComponent<BodyPart>();


                hairIndex = characterSelectionContinue.hairUI.currentBodyPartIndex;
                headIndex = characterSelectionContinue.headUI.currentBodyPartIndex;
                bodyIndex = characterSelectionContinue.bodyUI.currentBodyPartIndex;
                portraitIndex = characterSelectionContinue.portraitUI.currentBodyPartIndex;

                Debug.Log(hairIndex);
                Debug.Log(headIndex);
                Debug.Log(bodyIndex);
                Debug.Log("Portrait Index " +portraitIndex+ " Assigned Index "+characterSelectionContinue.portraitUI.currentBodyPartIndex);

                charController.hairParts[hairIndex].SetActive(true);
                charController.headParts[headIndex].SetActive(true);
                charController.bodyParts[bodyIndex].SetActive(true);
                //charController.playerPortraits[portraitIndex].SetActive(true);

                charController.bodyPartHair = charController.hairParts[hairIndex].GetComponent<BodyPart>();
                charController.bodyPartHead = charController.headParts[headIndex].GetComponent<BodyPart>();
                charController.bodyPartBody = charController.bodyParts[bodyIndex].GetComponent<BodyPart>();
                
                //spriteDepthSwapper.LoadCharacter();

                charLoad.variableStorage.SetValue("$playerName", new Yarn.Value(characterSelectionContinue.characterName)); 
                //charLoad.variableStorage.SetValue("$playerName", new Yarn.Value(data.CharacterName));
                Debug.Log("PlayerName: " + data.CharacterName);
                loadCharacter = false;
            }
            else
            {

            }
           
        }
    }
}
