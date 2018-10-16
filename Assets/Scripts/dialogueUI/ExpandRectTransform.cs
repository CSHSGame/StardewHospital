using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandRectTransform : MonoBehaviour {
    private float height;
	public void Expand(float amount)
    {
        RectTransform oldRect = this.GetComponent<RectTransform>();
        height = oldRect.sizeDelta.y;

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(oldRect.sizeDelta.x, height + amount);
        this.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;

    }
    public void ShrinkBack()
    {
        RectTransform oldRect = this.GetComponent<RectTransform>();

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(oldRect.sizeDelta.x, height);
        this.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
    }
}
