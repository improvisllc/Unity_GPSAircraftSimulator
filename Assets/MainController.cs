using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Maps.Coord;
using Google.Maps.Examples;

public class MainController : MonoBehaviour
{

    void Start()
    {
        GPSEncoder.SetLocalOrigin(new Vector2(40.186071f, 44.515081f)); //40.186071, 44.515081 OPERA THEATRE YEREVAN

        Vector2 ucsToGPS = GPSEncoder.USCToGPS(new Vector3(0.0f, 0.0f, 0.0f));
        //Vector2 ucsToGPS = GPSEncoder.USCToGPS(new Vector3(58.80884f, 0.0f, -179.6592f));

        //Debug.Log("UCS TO GPS LATITUDE :" + ucsToGPS.x);
        //Debug.Log("UCS TO GPS LONGITUDE :" + ucsToGPS.y);

        LatLng latlng = new LatLng(ucsToGPS.x, ucsToGPS.y);
        GameObject.Find("MapsExample").GetComponent<BaseMapLoader>().LatLng = latlng;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            GimbalController.rotateGimbalCamera(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.M))
        {
            GimbalController.rotateGimbalCamera(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.J))
        {
            GimbalController.rotateGimbalCamera(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GimbalController.rotateGimbalCamera(new Vector3(1, 0, 0));
        }
        if (Input.GetKey(KeyCode.R))
        {
            GimbalController.resetGimbalCameraRotation();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = GameObject.Find("CameraGimbal").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                print("RAYCAST HIT POINT: " + hit.point);
                
                Vector2 ucsToGPS = GPSEncoder.USCToGPS(new Vector3(hit.point.x, 0.0f, hit.point.z));

                Debug.Log("NEW LATITUDE :" + ucsToGPS.x);
                Debug.Log("NEW LONGITUDE :" + ucsToGPS.y);

                LatLng latlng = new LatLng(ucsToGPS.x, ucsToGPS.y);
                GameObject.Find("MapsExample").GetComponent<BaseMapLoader>().LatLng = latlng;

                Vector3 gpsToUCS = GPSEncoder.GPSToUCS(float.Parse(latlng.Lat.ToString()), float.Parse(latlng.Lng.ToString()));
                Camera.main.transform.position = new Vector3(gpsToUCS.x,Camera.main.transform.position.y,gpsToUCS.z);

                Debug.DrawRay(transform.position, transform.forward, Color.green);

            }
        }
    }
}
