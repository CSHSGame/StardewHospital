using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldToScreenTrack : MonoBehaviour
{
    public RectTransform myTransform;
    public RectTransform myTransformImage;

    public Transform target;
    public Vector3 screenPos2;
    public Vector3 dir;

    public Camera cam;
    public float heightOffSet = 10;
    public bool targetOnScreen = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            Rect rect = new Rect(0, 0, cam.pixelWidth, cam.pixelHeight);
            Vector3 screenPos = cam.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, target.position.z));

            screenPos2 = screenPos;

            if (rect.Contains(new Vector2(screenPos2.x, screenPos2.y)))
            {
                targetOnScreen = true;
                screenPos = cam.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, target.position.z + heightOffSet));
                myTransform.pivot =  new Vector2(0.5f, 0.5f);
            }
            else
            {
                targetOnScreen = false;
                myTransform.pivot = new Vector2(0, 0);

            }


            // Vector3 screenPos = cam.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, target.position.z + heightOffSet));

            screenPos = new Vector3(Mathf.Clamp(screenPos.x, 0, cam.pixelWidth - myTransform.rect.width), Mathf.Clamp(screenPos.y, 0, cam.pixelHeight -myTransform.rect.height), screenPos.z);
            myTransform.anchoredPosition3D = screenPos;
           

           // if (!test)
           // {
                dir = screenPos2 - myTransform.anchoredPosition3D;
                dir.Normalize();
              
                    
                    
                if (screenPos.x == 0)
                {
                    myTransformImage.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(dir, Vector3.down));

                }
                else
                {
                    myTransformImage.rotation = Quaternion.Euler(0, 0, Vector3.Angle(dir, Vector3.down));

                }
                //else if (screenPos.x == cam.pixelWidth)
                //{
                // //   myTransform.rotation = Quaternion.Euler(0, 0, 90);

                //}
                //else if (screenPos.x == cam.pixelWidth)
                //{
                //   // myTransform.rotation = Quaternion.Euler(0, 0, 90);

                //}



            //}
          //  else
           // {
               // myTransformImage.rotation = Quaternion.Euler(0, 0, 0);

          //  }
        }
       
	}
}
