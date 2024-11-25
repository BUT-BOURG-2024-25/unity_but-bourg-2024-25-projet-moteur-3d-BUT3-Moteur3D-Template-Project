using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Joystick joystick = null;
    
    public Vector2 JoystickDirection = Vector2.zero;

    public static UIManager Instance { get { return _instance; } }
    private static UIManager _instance = null;

    void Update()
    {
        JoystickDirection = new Vector2(joystick.Direction.x, joystick.Direction.y);
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
