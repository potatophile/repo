
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    // public float moveSpeed = 2f;
    // public float jumpSpeed = 5f;
    // // Update is called once per frame
    // void Update()
    // {
    //     float x = Input.GetAxis("Horizontal");
    //     float z = Input.GetAxis("Vertical");
    //     float y = Input.GetAxis("Jump");
        
        
    //     Rigidbody body = GetComponent<Rigidbody>();
    //     body.AddTorque(new Vector3(z, x , -x) * moveSpeed);

    //     Vector3 move = new Vector3(x, 0.0f, z);

    //     transform.position += move * moveSpeed * Time.deltaTime;
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         body.AddForce(Vector3.up * 10000);
        
    //     // Vector3 jump = new Vector3(0.0f, y, 0.0f);
    //     // transform.position += jump * jumpSpeed;
    //     }
    // }

    //declaring rigid body as rb
    public Rigidbody rb;

    //declaring variable for movementspeed 2f is enough
    public float movementspeed = 1100f;
    public float jumppower = 2500f;
    public float distToGround = 0.1f;

    //declaring private variables for directions
    private float xDirection;
    private float zDirection;
    private float yDirection = 55f;
    void Awake()
    {
        //gets rigidbody
        rb=GetComponent<Rigidbody>();
    }
    
    //use fixed update for force stuffs
    private void FixedUpdate()
    {
        Debug.Log(isGrounded());
        Move();
    }

    private void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xDirection,0f,zDirection)*movementspeed * Time.deltaTime);
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
    private void Jump()
    {
        
        rb.AddForce(new Vector3(0f,yDirection,0f)*jumppower * Time.deltaTime);
    }

}
