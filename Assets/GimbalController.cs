using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimbalController : MonoBehaviour
{
    public static void rotateGimbalCamera(Vector3 rotation)
    {
        GameObject.Find("CameraGimbal").transform.Rotate(rotation);
        //GameObject.Find("CameraGimbal").transform.eulerAngles = rotation;
    }
    public static void resetGimbalCameraRotation()
    {
        GameObject.Find("CameraGimbal").transform.localEulerAngles = Vector3.zero;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
