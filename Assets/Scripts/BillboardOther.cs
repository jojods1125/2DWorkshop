using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardOther : MonoBehaviour
{
    void Update()
    {
        Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(position, Vector3.up);
    }
}
