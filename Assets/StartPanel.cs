using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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


    // Use this for initialization
    void Start()
    {
        StartCoroutine(GrowLogo(2));
        StartCoroutine(TextOn(TextOnTime));
    }
	
	// Update is called once per frame
	void Update () {
        
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
}
