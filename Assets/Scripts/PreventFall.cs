using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PreventFall : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = player.GetComponent<Rigidbody>().velocity;
        //if (velocity.x + player.transform.rotation.x < -0.2)
            //player.transform.rotation = new Vector3(-0.2f, player.transform.rotation.y, player.transform.rotation.z); 


        //Debug.Log(player.transform.rotation.x +" "+player.transform.rotation.z);
    }
}
