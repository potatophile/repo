using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSphere : MonoBehaviour
{
    //declaring rigid body as player
    public Rigidbody player;
    public GameManager gamemanager;
    //declaring variable
    public float moveSpeed = 330f;
    public float jumpSpeed = 50f;
    public float distToGround = 0.25f;

    //declaring private variables for directions
    public float xDirection;
    public float zDirection;

    void Awake()
    {
        //gets rigidbody
        player=GetComponent<Rigidbody>();
    }

    public void Move() //Move function
    {   
        Vector3 inputVector = new Vector3(xDirection,0f,zDirection); //movement vector
        player.AddForce(Vector3.ClampMagnitude(inputVector,1f)*moveSpeed * Time.deltaTime); //Clamping to avoid adding force with diagonal movement
    }
    
    bool isGrounded() //Groundcheck boolean
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround); //checks if distToGround collision for groundcheck
    }
    
    public void Jump() //Jump function
    {
        //player.AddForce((new Vector3(0f,yDirection,0f) * jumpSpeed) * Time.deltaTime);
        player.AddForce(new Vector3(0, 2.5f, 0) * jumpSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    
    
    //use fixed update for force stuffs
    public void FixedUpdate()
    {
        Debug.Log(isGrounded()); //outputs ground check status
        if(player.transform.position.y < -50f )
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void Update() //runs once every frame
    {
        xDirection = Input.GetAxis("Horizontal"); 
        zDirection = Input.GetAxis("Vertical");

        Move();

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        ReStartGame();

    }
     public void ReStartGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
