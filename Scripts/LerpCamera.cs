using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCamera : MonoBehaviour
{


    public GameObject CamPoint;

    public float SmoothCam;



    void Update()
    {
        Vector3 pos = transform.position;
        pos.z= Mathf.Lerp(transform.position.z, CamPoint.transform.position.z, SmoothCam * Time.deltaTime);
        transform.position = pos;
    }
}
