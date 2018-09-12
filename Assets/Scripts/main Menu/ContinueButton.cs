using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Button()
    {
        StartCoroutine(PlayGame());
    }
    public IEnumerator PlayGame()
    {
       // SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
        //    Resources.FindObjectsOfTypeAll<ReviewDemoAug>()[0].load();
       
       
        yield return null;


        string name = "ALegitSceneName";
        AsyncOperation _async = new AsyncOperation();
        _async = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        _async.allowSceneActivation = true;

        while (!_async.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        //Scene nextScene = SceneManager.GetSceneByName(name);
        SceneManager.UnloadSceneAsync("Main Menu");
      
    }
}
