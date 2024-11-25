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
        
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        
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
    }
}
