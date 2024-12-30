using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoldat : MonoBehaviour
{
    public GameObject soldatGroup; // Le prefab du groupe de soldats
    public float distanceFromCamera = 10f; // Distance devant la caméra pour faire apparaître le groupe

    // Spawn le groupe de soldats
    public void SpawnSoldatGroup(Vector3 position)
    {
        Instantiate(soldatGroup, position, Quaternion.identity);
    }

    // Start is called before the first frame update
    public void Start()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Aucune caméra principale n'a été trouvée !");
            return;
        }

        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCamera;
        spawnPosition.y = 0.5f; // Fixe la hauteur
        SpawnSoldatGroup(spawnPosition);
    }



}
