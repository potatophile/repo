using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //declaring rigid body as rb
    public Rigidbody rb;

    //declaring variable for movementspeed 2f is enough
    public float movementspeed = 60f;
    public float jumppower = 20f;


    //declaring private variables for directions
    private float xDirection;
    private float zDirection;
    

    void Awake()
    {
        //gets rigidbody
        rb=GetComponent<Rigidbody>();
    }
    
    //use fixed update for force stuffs
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
            {
				Jump();
            }

     
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xDirection,0f,zDirection)*movementspeed*Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0f,100f,0f)*jumppower*Time.deltaTime);
    }

   
}
