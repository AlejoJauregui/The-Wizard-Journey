using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject targetToFollow;
    [SerializeField]
    Vector3 targetPosition;
    //PlayerController playerSpeed;
    [SerializeField]
    float cameraSpeed;
    //[SerializeField]
    Camera theCamera;
    //[SerializeField]

    Vector3 minLimits, maxLimits;
    float halfWidth, halfHeight;

    void Start() 
    {

    }
    // Update is called once per frame
    void Update()
    {
        FocusTheCamera();
    }
    void FocusTheCamera()
    {
        targetPosition = new Vector3 (targetToFollow.transform.position.x,targetToFollow.transform.position.y,this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position,targetPosition,cameraSpeed*Time.deltaTime);

        float clampX = Mathf.Clamp(this.transform.position.x, minLimits.x + halfWidth, maxLimits.x -  halfWidth);
        float clampY = Mathf.Clamp(this.transform.position.y, minLimits.y + halfHeight, maxLimits.y - halfHeight);
        this.transform.position = new Vector3 (clampX, clampY, this.transform.position.z);
    }
    public void ChangeLimits(BoxCollider2D newCameraLimits)
    {
        theCamera = GetComponent<Camera>();   
        //cameraLimits = GameObject.Find("CameraLimits").GetComponent<BoxCollider2D>();
        minLimits = newCameraLimits.bounds.min;
        maxLimits = newCameraLimits.bounds.max;
        halfWidth = theCamera.orthographicSize;
        halfHeight = halfWidth/Screen.width * Screen.height;
    }
}
