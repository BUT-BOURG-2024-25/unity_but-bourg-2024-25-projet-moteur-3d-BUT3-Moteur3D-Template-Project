using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.InputSystem.EnhancedTouch;


public class MovePositionByAxis : MonoBehaviour
{
    [SerializeField]
    float speed =-1f;

    private GameObject player = null;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        Vector2 NewVelocity = UIManager.Instance.JoystickDirection;
        player.GetComponent<Rigidbody>().velocity = new Vector3(NewVelocity.x*speed, player.GetComponent<Rigidbody>().velocity.y, NewVelocity.y*speed/*z*/);
       
        //player.GetComponent<Rigidbody>().velocity = new Vector3(InputManager.Instance.MovementInput.x * speed+2, player.GetComponent<Rigidbody>().velocity.y, InputManager.Instance.MovementInput.y/*z*/ * speed);
    }
}
