using System.Collections;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed = 0.5f;
    public float xOff, yOff, zOff;
    // Update is called once per frame
    void LateUpdate()
    {   
        Vector3 desiredPosition = target.transform.position + new Vector3(xOff, yOff, zOff);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
        
        transform.LookAt(target.transform.position);
    }
        
}
