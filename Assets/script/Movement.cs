using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // variables
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundMask;
    public GameOver GameOverController;
    Rigidbody playerRB;
    bool isGrounded = false;
    float groundDistance = 0.4f;
    // the defulat is that the game is on going
    private bool isTheGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTheGameOver)
        {

            Move();
            Jump();

        }
    }

    void Move()
    {
        // x == 1 if the input is (D, right arrow) x == -1 if the input is (A, left arrow)
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        // this only changes the x vetor and the y stayes `playerRB.velocity.y`
        // if the value of x is -1 it will move backwoard 
        playerRB.velocity = new Vector2(moveBy, playerRB.velocity.y);
    }


    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            GameOverController.setUp();
            // change to stop the movement 
            isTheGameOver = true;
        }
    }


    public bool GameStatusIsOver()
    {
        return isTheGameOver;
    }
}
