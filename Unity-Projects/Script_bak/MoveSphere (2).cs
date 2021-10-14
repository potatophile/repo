using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    //declaring rigid body as player
    public Rigidbody player;

    //declaring variable
    public float moveSpeed = 330f;
    public float jumpSpeed = 100f;
    public float distToGround = 0.25f;

    //declaring private variables for directions
    private float xDirection;
    private float zDirection;

    void Awake()
    {
        //gets rigidbody
        player=GetComponent<Rigidbody>();
    }

    private void Move() //Move function
    {   
        Vector3 inputVector = new Vector3(xDirection,0f,zDirection); //movement vector
        player.AddForce(Vector3.ClampMagnitude(inputVector,1f) * moveSpeed * Time.deltaTime); //Clamping to avoid adding force with diagonal movement
    }
    
    bool isGrounded() //Groundcheck boolean
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround); //checks if distToGround collision for groundcheck
    }
    
    private void Jump() //Jump function
    {
        //player.AddForce((new Vector3(0f,yDirection,0f) * jumpSpeed) * Time.deltaTime);
        player.AddForce(new Vector3(0, 2.5f, 0) * jumpSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    
    //use fixed update for force stuffs
    private void FixedUpdate()
    {
        Debug.Log(isGrounded()); //outputs ground check status
        
    }

    private void Update() //runs once every frame
    {
        xDirection = Input.GetAxis("Horizontal"); 
        zDirection = Input.GetAxis("Vertical");
        
        if (isGrounded())
        {
            Move();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }        
    }
}
