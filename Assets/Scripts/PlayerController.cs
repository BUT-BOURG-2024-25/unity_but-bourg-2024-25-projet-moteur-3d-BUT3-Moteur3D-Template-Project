using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    private int desiredLane = 1;//0 gauche 1 milieu 2 droite
    public float laneDistance = 4;

    public float jumpForce;
    public float Gravity = -20;
    
    public Animator animator;
    
    public float forwardSpeed;
    public float maxSpeed;
    public PlayerManager playerManager;
    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed+= 0.01f * Time.deltaTime;
        }
        
        
        animator.SetFloat("MovePlayer",forwardSpeed);
        direction.z = forwardSpeed;
        direction.y += Gravity * Time.deltaTime;
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp)
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * (25 * Time.deltaTime);
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
     direction.y = jumpForce;
     
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (playerManager != null)
        {
            playerManager.HandleCollision(hit.transform);
        }
    }



    private IEnumerator Slide()
    {
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, +0.5f, 0);
        controller.height = 1;
        yield return new WaitForSeconds(1f);
        controller.center = new Vector3(0, 1, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        
    }
}
