using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject solPrefab; // Le préfab du sol
    public float segmentLength = 20f; // Longueur de chaque segment
    public float spawnDistance = 10f; // Distance après laquelle un nouveau segment est généré
    public float deleteDistance = 10f; // Distance avant laquelle les segments sont supprimés (plus tôt qu'avant)
    public int numberOfSegments = 7; // Nombre de segments visibles à tout moment

    private List<GameObject> segments; // Liste des segments de sol
    private Transform cameraTransform; // La caméra
    private List<PortalManager> portalManagers; // Liste des gestionnaires de portails

    void Start()
    {

        Debug.Log("LineGenerator Start");
        cameraTransform = Camera.main.transform; // Récupère la caméra principale
        segments = new List<GameObject>();
        portalManagers = new List<PortalManager>(); // Liste des gestionnaires de portails

        // Créer les segments de sol initiaux
        for (int i = 0; i < numberOfSegments; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, i * segmentLength); // Position initiale des segments
            GameObject newSegment = Instantiate(solPrefab, spawnPosition, Quaternion.identity);
            segments.Add(newSegment);

            // Ajouter le gestionnaire de portails du segment
            PortalManager portalManager = newSegment.GetComponent<PortalManager>();
            if (portalManager != null)
            {
                portalManagers.Add(portalManager);

                // Générer les portails pour ce segment
                Vector3 portalPosition1 = newSegment.transform.position + new Vector3(-1.1f, 0.5f, 0);
                Vector3 portalPosition2 = newSegment.transform.position + new Vector3(1.1f, 0.5f, 0);
                portalManager.SpawnPortal(portalPosition1);
                portalManager.SpawnPortal(portalPosition2);
            }
        }
    }

    public void Initialize()
    {
        cameraTransform = Camera.main.transform; // Assurez-vous que la caméra est bien attribuée
        segments = new List<GameObject>();
        portalManagers = new List<PortalManager>();

        // Recréez la ligne de départ
        for (int i = 0; i < numberOfSegments; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, i * segmentLength);
            GameObject newSegment = Instantiate(solPrefab, spawnPosition, Quaternion.identity);
            segments.Add(newSegment);

            PortalManager portalManager = newSegment.GetComponent<PortalManager>();
            if (portalManager != null)
            {
                portalManagers.Add(portalManager);
                Vector3 portalPosition1 = newSegment.transform.position + new Vector3(-1.1f, 0.5f, 0);
                Vector3 portalPosition2 = newSegment.transform.position + new Vector3(1.1f, 0.5f, 0);
                portalManager.SpawnPortal(portalPosition1);
                portalManager.SpawnPortal(portalPosition2);
            }
        }
    }


    void Update()
    {
        MoveCamera();
        ManageLine();
    }

    void MoveCamera()
    {
        // Déplacer la caméra
        cameraTransform.Translate(Vector3.forward * 12f * Time.deltaTime); // Vitesse ajustée à 6f
    }

    void ManageLine()
    {
        // Gérer les segments de sol en fonction de la position de la caméra
        for (int i = 0; i < segments.Count; i++)
        {
            GameObject segment = segments[i];

            // Si la caméra est à une certaine distance avant le segment, on le supprime

            if (segment.transform.position.z + segmentLength < cameraTransform.position.z - deleteDistance)
            {
                // Supprimer les portails associés au segment
                PortalManager portalManager = portalManagers[i];
                if (portalManager != null)
                {
                    portalManager.DestroyPortals(); // Appelle la méthode pour supprimer les portails
                }

                // Supprimer le segment
                Destroy(segment);
                segments.RemoveAt(i);
                portalManagers.RemoveAt(i); // Retirer le gestionnaire de portails
                i--; // Décalage de l'indice pour éviter de sauter un segment après suppression
            }
        }

        // Ajouter un nouveau segment si nécessaire
        if (segments.Count < numberOfSegments)
        {
            // Assurer que la position du prochain segment soit correctement calculée
            Vector3 newPosition = segments[segments.Count - 1].transform.position + new Vector3(0, 0, segmentLength);
            GameObject newSegment = Instantiate(solPrefab, newPosition, Quaternion.identity);
            segments.Add(newSegment);

            // Ajouter le gestionnaire de portails pour ce segment
            PortalManager portalManager = newSegment.GetComponent<PortalManager>();
            if (portalManager != null)
            {
                portalManagers.Add(portalManager);

                // Générer les portails pour ce nouveau segment
                Vector3 portalPosition1 = newSegment.transform.position + new Vector3(-1.1f, 0.5f, 0);
                Vector3 portalPosition2 = newSegment.transform.position + new Vector3(1.1f, 0.5f, 0);
                portalManager.SpawnPortal(portalPosition1);
                portalManager.SpawnPortal(portalPosition2);
            }
        }
    }
}
