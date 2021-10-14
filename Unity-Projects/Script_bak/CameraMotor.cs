using System.Collections;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed = 0.5f; //smoothe camera movement
    public float xOff, yOff, zOff; //offset values
    
    // Update is called once per frame
    void LateUpdate() 
    {   
        Vector3 desiredPosition = target.transform.position + new Vector3(xOff, yOff, zOff);  //camera's position with offset to player's position

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //Lerp vector interpolates between camera's actual and desired position
        
        transform.position = smoothedPosition; 
        
        transform.LookAt(target.transform.position); 
    }
        
}
