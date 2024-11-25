using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using UnityEditor;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference MovementAction;

    public Vector2 MovementInput { get; private set; }
    public static InputManager Instance { get { return _instance; } }
    private static InputManager _instance = null;

    public void Start()
    {

    }
    void Update()
    {
        Vector2 MoveInput = MovementAction.action.ReadValue<Vector2>();

        //Debug.Log(MoveInput.x+ " "+MoveInput.y);

        MovementInput = new Vector3(MoveInput.x, 0, MoveInput.y);
    }

    private void Awake()

    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
