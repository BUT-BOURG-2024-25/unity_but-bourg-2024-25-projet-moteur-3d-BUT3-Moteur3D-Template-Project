using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portalPrefab; // Le prefab du portail
    public float portalSpacing = 2f; // Espacement entre les portails
    public int numberOfPortals = 2; // Nombre de portails à générer

    private List<GameObject> portals = new List<GameObject>(); // Liste des portails générés pour ce segment

    public void SpawnPortal(Vector3 position)
    {
        // Crée un nouveau portail
        GameObject newPortal = Instantiate(portalPrefab, position, Quaternion.identity);
        Material randomMaterial = null;

        portals.Add(newPortal); // Ajoute le portail à la liste
    }

    public void DestroyPortals()
    {
        // Détruit tous les portails associés à ce segment de sol
        foreach (GameObject portal in portals)
        {
            Destroy(portal);
        }

        portals.Clear(); // Vide la liste après suppression
    }
}
