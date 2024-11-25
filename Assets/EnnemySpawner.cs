using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    [SerializeField]
    float deltaTime = -1f; //Durée de spawn
    [SerializeField]
    Vector2 spawnDistanceToPlayer = Vector2.zero; //Distance de grâce

    [SerializeField]
    float intervalRandomRange = -1f; //Variation par rapport aux paramètres définis par l'aléatoire

    [SerializeField]
    GameObject spawnPlane = null; //Spawner
    void Update()
    {
        spawnEnnemy();
    }

    IEnumerator spawnEnnemy()
    {
        yield return new WaitForSeconds(deltaTime);
    }
}
