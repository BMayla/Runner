﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 4; //the distance between two lanes

    public float jumpForce;
    public float Gravity = -20;
    // public bool isGrounded;
    // public LayerMask groundLayer;
    //public Transform groundCheck;




    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (controller.isGrounded)
        {/*
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))   //(isGrounded)
            {
                Jupm();
            }
        
        }else{
            direction.y += Gravity* Time.deltaTime;
        }

        //isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);*/

            //Gather the inputs on which lane we should be
            /*if (Input.GetKeyDown(KeyCode.RightArrow))   //(isGrounded)
                    {
                        desiredLane++;
                        if (desiredLane == 3)
                            desiredLane = 2;
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        desiredLane--;
                        if (desiredLane == -1)
                            desiredLane = 0;
                    }

            */
            direction.y = -2;
            if (SwipeManager.swipeUp)
            {
                Jupm();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        //Gather the inputs on which lane we should be

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        //transform.position = targetPosition;

        //transform.position = Vector3.Lerp(transform.position,targetPosition, 70*Time.deltaTime);

        /*
         * or
         * controller.center = controller.center;//   the player didn't  pass throw the traficoin it collied with them  */

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 24 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.magnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);


    }


    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jupm()
    {
        direction.y = jumpForce;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "obstacle")
        {
            PlayerManager.gameOver = true;
            //FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
}

