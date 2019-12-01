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

    // Start is called before the first frame update
    void Awake()
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
    }
}
