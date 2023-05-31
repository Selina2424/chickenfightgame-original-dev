using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimations playerAnimations;

    public float movement_Speed = 3f;  //presents and allows to edit character model's behaviour
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;



    // First function that will be called
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
       Move(); 
       Rotate();
       AnimateWalk();
    }
    void Move()
    {
        if(Input.GetAxis(Axis.VERTICAL_AXIS)>0)  //determines if the player is pressing up or down the Y axis
        {
            Vector3 moveDirection = transform.forward;  //moving forward
            moveDirection.x -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime); //detirmines speed of moving forward

        }
        else if(Input.GetAxis(Axis.VERTICAL_AXIS)<0)
        {
            Vector3 moveDirection = -transform.forward;  //moving backward
            moveDirection.x -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime); //detirmines speed on moving backward
        }
        else // if there no input to move character
        {
            charController.Move(Vector3.zero); //sets values to 0,0,0
        }

    } //move

    void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero; //resets if theres a taken input thats not zero to zero
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) <0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.left); //rotating left
        }
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) >0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.right); //rotating right
        }
        if(rotation_Direction != Vector3.zero) //when the user enters an input
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction), //rotates from current direction taken from user input
                rotateDegreesPerSecond * Time.deltaTime);  
        }
    } //rotate

    void AnimateWalk()
     {   
        if(charController.velocity.sqrMagnitude != 0f) //gets the speed/time, velocity carries value of x,y,z, squareroot magnitude will make the value=1 

        {                                              //if there's no value the character won't execute the walking animation
            playerAnimations.Walking(true);
        }
        else
            {
                playerAnimations.Walking(false);
            }
    }
} // class
