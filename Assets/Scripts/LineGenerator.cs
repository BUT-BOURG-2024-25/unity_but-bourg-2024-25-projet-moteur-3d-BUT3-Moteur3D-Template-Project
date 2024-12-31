using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject solPrefab; // Le prefab de la plateforme
    public GameObject trapPrefab; // Le prefab des pi�ges
    public float segmentLength = 20f; // Longueur de chaque segment
    public int numberOfSegments = 7; // Nombre de segments visibles
    public Transform groupSoldat; // R�f�rence au groupe de soldats

    private List<GameObject> segments; // Liste des segments de plateforme
    private Transform cameraTransform; // R�f�rence � la cam�ra principale
    private List<PortalManager> portalManagers; // Liste des gestionnaires de portails
    private int spawnToggleCounter = 0; // Compteur pour alterner le spawn des ennemis et des pi�ges
    private int segmentIndex = 0; // Compteur global des segments

    void Start()
    {
        Debug.Log("LineGenerator Start");

        cameraTransform = Camera.main.transform; // R�cup�rer la cam�ra principale
        segments = new List<GameObject>();
        portalManagers = new List<PortalManager>();

        // Cr�er les segments initiaux
        for (int i = 0; i < numberOfSegments; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, i * segmentLength);
            GameObject newSegment = Instantiate(solPrefab, spawnPosition, Quaternion.identity);
            segments.Add(newSegment);

            PortalManager portalManager = newSegment.GetComponent<PortalManager>();
            if (portalManager != null)
            {
                portalManagers.Add(portalManager);

                // G�n�rer les portails
                portalManager.SpawnPortals(newSegment.transform.position);

                // G�n�rer des pi�ges ou des ennemis
                if (segmentIndex >= 2)
                {
                    if (spawnToggleCounter % 4 == 0) // Rien
                    {
                        // Pas d'action
                    }
                    else if (spawnToggleCounter % 4 == 1) // Ennemis
                    {
                        portalManager.SpawnEnemies();
                    }
                    else if (spawnToggleCounter % 4 == 3) // Pi�ges
                    {
                        portalManager.SpawnTrap(trapPrefab);
                    }
                }

                spawnToggleCounter++;
            }
            segmentIndex++;
        }
    }

    public void Initialize()
    {
        Debug.Log("LineGenerator Initialize");

        cameraTransform = Camera.main.transform; // Assurez-vous que la cam�ra est bien attribu�e
        segments = new List<GameObject>();
        portalManagers = new List<PortalManager>();

        // Recr�ez la ligne de d�part
        for (int i = 0; i < numberOfSegments; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, i * segmentLength);
            GameObject newSegment = Instantiate(solPrefab, spawnPosition, Quaternion.identity);
            segments.Add(newSegment);

            PortalManager portalManager = newSegment.GetComponent<PortalManager>();
            if (portalManager != null)
            {
                portalManagers.Add(portalManager);
                portalManager.SpawnPortals(newSegment.transform.position);

                // G�n�rer des pi�ges ou des ennemis
                if (segmentIndex >= 2)
                {
                    if (spawnToggleCounter % 4 == 1) // Ennemis
                    {
                        portalManager.SpawnEnemies();
                    }
                    
                    else if (spawnToggleCounter % 4 == 3) // Pi�ges
                    {
                        portalManager.SpawnTrap(trapPrefab);
                    }
                }

                spawnToggleCounter++;
            }
            segmentIndex++;
        }
    }

    void Update()
    {
        MoveCamera();
        ManageLine();
    }

    void MoveCamera()
    {
        if (groupSoldat != null)
        {
            Vector3 cameraPosition = cameraTransform.position;
            cameraPosition.z = groupSoldat.position.z - 10f; // Garde une distance de 10 unit�s derri�re
            cameraTransform.position = cameraPosition;
        }
        else
        {
            // D�place la cam�ra automatiquement si le groupe n'est pas assign�
            cameraTransform.Translate(Vector3.forward * 12f * Time.deltaTime);
        }
    }

    void ManageLine()
    {
        // G�rer les segments en fonction de la position de la cam�ra
        for (int i = 0; i < segments.Count; i++)
        {
            GameObject segment = segments[i];

            // Supprimer les segments �loign�s de la cam�ra
            if (segment.transform.position.z + segmentLength < cameraTransform.position.z)
            {
                PortalManager portalManager = portalManagers[i];
                if (portalManager != null)
                {
                    portalManager.DestroyPortalsAndEnemies(); // D�truit les portails, ennemis et pi�ges
                }

                Destroy(segment);
                segments.RemoveAt(i);
                portalManagers.RemoveAt(i);
                i--;
            }
        }

        // Ajouter un nouveau segment si n�cessaire
        if (segments.Count < numberOfSegments)
        {
            Vector3 newPosition = segments[segments.Count - 1].transform.position + new Vector3(0, 0, segmentLength);
            GameObject newSegment = Instantiate(solPrefab, newPosition, Quaternion.identity);
            segments.Add(newSegment);

            PortalManager portalManager = newSegment.GetComponent<PortalManager>();
            if (portalManager != null)
            {
                portalManagers.Add(portalManager);

                // G�n�rer les portails
                portalManager.SpawnPortals(newSegment.transform.position);

                // G�n�rer des pi�ges ou des ennemis
                if (segmentIndex >= 2)
                {
                    if (spawnToggleCounter % 4 == 1) // Ennemis
                    {
                        portalManager.SpawnEnemies();
                    }
                    
                    else if (spawnToggleCounter % 4 == 3) // Pi�ges
                    {
                        portalManager.SpawnTrap(trapPrefab);
                    }
                }

                spawnToggleCounter++;
            }
            segmentIndex++;
        }
    }
}
