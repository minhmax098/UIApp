using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    private Camera camera; 
    private GameObject gyroscope;

    private float perspectiveZoomSpeed = 0.05f; 
    private float orthoZoomSpeed = 0.05f; 

    private float eigen = 0.005f; 

    Touch touchZero; 
    Touch touchOne; 
    Vector2 touchZeroPrevPos; 
    Vector2 touchOnePrevPos; 
    float preTouchDeltaMag; 
    float touchDeltaMag; 
    float deltaMagnitudeDiff; 


    Touch touch; 
    float horizontal; 
    float vertical; 

    private float Azi = 0f; 
    private float Ele = 0f; 
    float sensitivity = 5f; 
    
    Gesture currentGes; 

    enum Gesture {
        None, 
        Stationary, 
        Press, 
        Swipe
    }

    Vector2 oriPosition; 


    // Start is called before the first frame update
    void Start()
    {
       gyroscope = gameObject.Find("Gyroscope"); 
       camera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        currentGes = Gesture.None; 
        if (Input.touchCount < 1)
        {
            return; 

        }
        Touch touch = Input.GetTouch(0);

        if(Input.touchCount == 1 && Helper.GetObjectInSpaceOnTouchByTag(touch.position, objectTag.mainView))
        {
            HandleSingleTouch(touch);

        }
        if(Input.touchCount == 2)
        {
            HandleMultiTouch(touch); 

        }
    }

    private void HandleSingleTouch(Touch touch)
    {
        switch(touch.phase)
        {
            case TouchPhase.Began: 
                oriPosition = touch.Position; 
                break; 

            case TouchPhase.Moved:
                Vector2 data = touch.position - oriPosition; 
                if(deltaMagnitudeDiff.magnitude > sensitivity)
                    Move(touch, delta); 
                break; 

            case TouchPhase.Stationary:
                currentGes = Gesture.Stationary; 
                break; 
            
            case TouchPhase.Stationary:
                currentGes = Gesture.Stationary; 
                break; 

            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                currentGes = Gesture.None; 
                break; 
        }
    }

    private void HandleMultiTouch(Touch touch)
    {
        touchZero = Input.GetTouch(0); 
        touchOne = Input.GetTouch(1); 

        touchZeroPrevPos = touchZero.position - touchZero.deltaposition; 
        touchOnePrevPos = touchOne.position - touchOne.deltaposition; 

        prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; 
        touchDeltaMag = (touchZero.position - touchOne.position).magnitude; 

        //Find the difference in the distance between each frame 
        deltaMagnitudeDiff  = prevTouchDeltaMag - touchDeltaMag; 

        // Iff the camera is orthographic 
    }
}
