using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(50*Time.deltaTime,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickupCoin");
            PlayerManager.numberOfCoins += 1;
            Destroy(gameObject);
        }
    }
}
