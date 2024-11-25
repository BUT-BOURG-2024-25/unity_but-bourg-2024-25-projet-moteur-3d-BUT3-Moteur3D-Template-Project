using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoldat : MonoBehaviour
{
    [SerializeField]
    private LayerMask GroundLayer;

    [SerializeField]
    private GameObject objectToSpawn;

    [SerializeField]
    private float spawnRadius = 2.0f;

    [SerializeField]
    private float checkRadius = 1.0f;

    [SerializeField]
    private int maxAttempts = 10;

    private Transform playerTransform;
    private Transform groupSoldatTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        groupSoldatTransform = GameObject.Find("groupSoldat").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clic gauche
        {
            SpawnObjectNearPlayer();
        }
    }

    private void SpawnObjectNearPlayer()
    {
        Vector3 spawnPosition = Vector3.zero;
        bool positionFound = false;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
            randomDirection.y = 0; 
            spawnPosition = playerTransform.position + randomDirection;
            spawnPosition.y = playerTransform.position.y+1; // Assurez-vous que l'objet est au même niveau que le joueur

            // Vérifiez si la position est libre
            Collider[] colliders = Physics.OverlapSphere(spawnPosition, checkRadius, GroundLayer);
            if (colliders.Length == 0)
            {
                positionFound = true;
                break;
            }
        }

        if (positionFound)
        {
            GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            newObject.transform.SetParent(groupSoldatTransform);
        }
        else
        {
            Debug.Log("Impossible de trouver une position libre après plusieurs tentatives.");
        }
    }
}
