using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour {


    public RectTransform BloomLogo1;
    public RectTransform BloomLogo2;
    public float LogoGrowTime = 2.0f;
    public Vector2 LogoSmallSize;
    public Vector2 LogoLargeSize;


    public GameObject StartText1;
    public GameObject StartText2;
    public float TextOnTime = 1.0f;
    public float TextOffTime = 0.5f;

    public bool isStart = true;

    public string StartMainText;
    public string EndMainText;

    public GameObject StartSplash;
    public GameObject EndSplash;

    // Use this for initialization
    void Start()
    {

        Text maintext1 = StartText1.GetComponent<Text>();
        Text maintext2 = StartText2.GetComponent<Text>();


        if (isStart)
        {
            maintext1.text = StartMainText;
            maintext2.text = StartMainText;
            StartCoroutine(GrowLogo(2));
            StartCoroutine(TextOn(TextOnTime));

        }
        else
        {
            maintext1.text = EndMainText;
            maintext2.text = EndMainText;
            StartCoroutine(GrowLogo(2));
        }

    }
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKey(KeyCode.Space))
        {
            if(isStart)
            {
                StartCoroutine(StartSpashTimer());
               
            }
        }

    }

    IEnumerator GrowLogo(float time)
    {

        Vector2 SmallScale = LogoSmallSize;
        Vector2 LargeScale = LogoLargeSize;
        float growTime = 0.0f;

        do
        {
            BloomLogo1.sizeDelta = Vector2.Lerp(SmallScale, LargeScale, growTime / time);
            BloomLogo2.sizeDelta = Vector2.Lerp(SmallScale, LargeScale, growTime / time);

            growTime += Time.deltaTime;

            yield return null;

        } while (growTime <= time);

        growTime = 0.0f;
        StartCoroutine(ShrinkLogo(2));
    }

    IEnumerator ShrinkLogo(float time)
    {
        Vector2 SmallScale = LogoSmallSize;
        Vector2 LargeScale = LogoLargeSize;
        float shrinkTime = 0.0f;

        do
        {
            BloomLogo1.sizeDelta = Vector2.Lerp(LargeScale, SmallScale, shrinkTime / time);
            BloomLogo2.sizeDelta = Vector2.Lerp(LargeScale, SmallScale, shrinkTime / time);

            shrinkTime += Time.deltaTime;

            yield return null;

        } while (shrinkTime <= time);

        shrinkTime = 0.0f;
        StartCoroutine(GrowLogo(2));
    }

    IEnumerator TextOn(float time)
    {
        float OnTime = 0.0f;

        do
        {
            StartText1.SetActive(true);
            StartText2.SetActive(true);

            OnTime += Time.deltaTime;

            yield return null;

        } while (OnTime <= time);

        OnTime = 0.0f;
        StartCoroutine(TextOff(TextOffTime));
    }
    IEnumerator TextOff(float time)
    {
        float OffTime = 0.0f;

        do
        {
            StartText1.SetActive(false);
            StartText2.SetActive(false);

            OffTime += Time.deltaTime;

            yield return null;

        } while (OffTime <= time);

        OffTime = 0.0f;
        StartCoroutine(TextOn(TextOnTime));
    }

    public IEnumerator StartSpashTimer()
    {
        StartSplash.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        //Debug.Log("Load Game Scene");
        SceneManager.LoadScene(1);
    }

    public IEnumerator EndSplashTimer()
    {
        EndSplash.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        //Debug.Log("Load Start Scene");
        SceneManager.LoadScene(0);
    }
}
