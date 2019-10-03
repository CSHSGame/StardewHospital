using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldToScreenTrack : MonoBehaviour
{
    public RectTransform myTransform;
    public RectTransform myTransformImage;

    public Transform target;
    Vector3 screenPos2;
    Vector3 dir;

    public Camera cam;
    public float heightOffSet = 0;
    public bool targetOnScreen = false;

    public Vector2 bufferZone;
    // Use this for initialization
    void Start () {
        cam = Camera.main;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            if (FadeMode.isOn)
            {
                myTransformImage.gameObject.SetActive(false);
                return;
            }

            Rect rect = new Rect(0, 0, cam.pixelWidth - bufferZone.x, cam.pixelHeight - bufferZone.y);
            Vector3 screenPos = cam.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, target.position.z));

            screenPos2 = screenPos;

            if (rect.Contains(new Vector2(screenPos2.x, screenPos2.y)))
            {
                targetOnScreen = true;
            }
            else
            {
                targetOnScreen = false;          
            }

            float leftEdge = (myTransform.rect.width / 2) + bufferZone.x;
            float rightEdge = cam.pixelWidth - myTransform.rect.width / 2 - bufferZone.x;
            float topEdge = cam.pixelHeight - (myTransform.rect.height / 2) - bufferZone.y;
            float bottomEdge = (myTransform.rect.height / 2) + bufferZone.y;
            // Vector3 screenPos = cam.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, target.position.z + heightOffSet));
            screenPos = cam.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, target.position.z + heightOffSet));

            screenPos = new Vector3(Mathf.Clamp(screenPos.x, leftEdge, rightEdge), Mathf.Clamp(screenPos.y, bottomEdge, topEdge), screenPos.z);
            myTransform.anchoredPosition3D = screenPos;
           

          
                dir = screenPos2 - myTransform.anchoredPosition3D;
                dir.Normalize();
              
                    
                    
                if (screenPos.x == leftEdge)
                {
                    myTransformImage.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(dir, Vector3.down));

                }
                else
                {
                    myTransformImage.rotation = Quaternion.Euler(0, 0, Vector3.Angle(dir, Vector3.down));

                }



            myTransformImage.gameObject.SetActive(!targetOnScreen);
            


        }
        else
        {
            myTransformImage.gameObject.SetActive(false);

        }
       
	}
}
