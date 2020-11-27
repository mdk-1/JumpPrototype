using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to control camera follow

public class CameraManager : MonoBehaviour
{
    public Transform target;
    private float smoothSpeed = .3f;
    private Vector3 currentVelocity;

    //apply smooth damp to lateupdate to allow camera to follow player along Y axis smoothly
    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, smoothSpeed * Time.deltaTime);
        }   
    }
}
