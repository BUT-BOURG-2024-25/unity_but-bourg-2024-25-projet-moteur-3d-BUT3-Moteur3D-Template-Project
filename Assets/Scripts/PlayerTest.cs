using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
           
            transform.Translate(Vector3.right * Time.deltaTime);
        }

        
        if (Input.GetMouseButtonDown(0)) // Clic gauche
        {
            Debug.Log("Clic gauche détecté");
        }
    }
}
