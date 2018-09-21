using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
       if (!SaveManager.GetIfFileExist(SaveManager.defaultSaveName))
       {
            this.gameObject.SetActive(false);
       }
    }
	

    public void Button()
    {
        StartCoroutine(PlayGame());
    }
    public IEnumerator PlayGame()
    {
        // SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
        //    Resources.FindObjectsOfTypeAll<ReviewDemoAug>()[0].load();
        HospitalSaveData data = new HospitalSaveData();
        data = (HospitalSaveData)SaveManager.Load();

        

        yield return null;
        string name = "AITestscene";

        if (data != null)
        {
            name = data.SceneName;
        }
        AsyncOperation _async = new AsyncOperation();
        _async = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        _async.allowSceneActivation = true;

        while (!_async.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));

        if (data != null)
        {
            ExampleVariableStorage variableStorage = GameObject.FindObjectOfType<ExampleVariableStorage>();
            if(variableStorage != null)
                data.Load(variableStorage);
        }
        //Scene nextScene = SceneManager.GetSceneByName(name);
        SceneManager.UnloadSceneAsync("Main Menu");
      
    }
}
