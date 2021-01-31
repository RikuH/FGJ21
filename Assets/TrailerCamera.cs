using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    float smoothspeed = 0.125f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        transform.position = smoothedPosition;
    }
}
