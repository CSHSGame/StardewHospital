using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoSceneSwitcher : MonoBehaviour {
    public float Delay = 3;
    public bool MainMenu = false;
    public int SceneA;
    public int SceneB;

    public int NextScene;
    // Use this for initialization
    void Start () {
		
	}
	public static void ChangeScene (int scene)
    {
        SceneManager.LoadScene(scene);
    }
	// Update is called once per frame
	void Update () {
        Delay -= Time.deltaTime;
        if (Delay <= 0)
        {
            if (Input.anyKey)
            {

                float random = Random.value;

                if (random > 0.5f)
                {
                    SceneManager.LoadScene(SceneA);
                }
                else
                {
                    SceneManager.LoadScene(SceneB);
                }
            }
        }

	}
}
