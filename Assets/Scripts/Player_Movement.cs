using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour
{
    public GameObject pause;

    public bool gamePaused = false;
    public float verticalInput;
    public float horizontalInput;

    public float speed = 10;
    public float turnSpeed = 3;

    public Rigidbody rb;

    public static bool cStop = false;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pause.SetActive(false);
    }
    
    void Update()
    {
        //Get User Input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //Move the player with velocity
        Vector3 forwardMove = transform.forward * verticalInput * speed;
        Vector3 rightMove = transform.right * horizontalInput * speed;
        Vector3 upMove = new Vector3(0, rb.velocity.y, 0);

        rb.velocity = forwardMove + rightMove + upMove;

        float MouseX = Input.GetAxis("Mouse X");
        

        //Rotate the player
        Vector3 rotateVector = new Vector3(0, MouseX, 0);

        transform.Rotate(rotateVector * turnSpeed);

        //pause the  game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
         if(gamePaused)
             UnPause();
         else
             Pause();
 
         gamePaused = !gamePaused;
        }
    }

    //this unpauses game
    private void UnPause()
    {

        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        cStop = false;

        pause.SetActive(false);
    }

    //this pauses game(DONT CHANGE I HAVE NO IDEA WHY IT WORKS OK)
    private void Pause()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cStop = true;

        pause.SetActive(true);
    }
}