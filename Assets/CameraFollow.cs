using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform subject;
    public float yClamp;

    // Update is called once per frame
    void Update()
    {
        float yPos = Mathf.Clamp(subject.position.y, yClamp, Mathf.Infinity);
        transform.position = new Vector3(subject.position.x, yPos, transform.position.z);
        
    }
}
