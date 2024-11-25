using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portalPrefab; // Le prefab du portail
    public Material redMaterial; // Matériau rouge
    public Material blueMaterial; // Matériau bleu
    public float portalSpacing = 2f; // Espacement entre les portails
    public int numberOfPortals = 2; // Nombre de portails à générer

    private List<GameObject> portals = new List<GameObject>(); // Liste des portails générés pour ce segment

    public void SpawnPortal(Vector3 position)
    {
        // Crée un nouveau portail
        GameObject newPortal = Instantiate(portalPrefab, position, Quaternion.identity);
        Material randomMaterial = null;

        // Change la couleur aléatoire
        Renderer portalRenderer = newPortal.GetComponent<Renderer>();
        if (portalRenderer != null)
        {
            randomMaterial = Random.value > 0.5f ? redMaterial : blueMaterial;
            portalRenderer.material = randomMaterial;
        }

        // Configure le texte
        TextMeshPro text = newPortal.GetComponentInChildren<TextMeshPro>();
        if (text != null)
        {
            // Génère un symbole et une valeur
            string[] symbols = { "-", "+", "x" };
            string randomSymbol;
            int randomValue;

            if (randomMaterial == redMaterial)
            {
                randomSymbol = symbols[0];
                randomValue = Random.Range(1, 11); // Valeur entre 1 et 10
            }
            else
            {
                randomSymbol = symbols[Random.Range(1, 3)];
                if (randomSymbol == "x")
                {
                    randomValue = Random.Range(1, 4); // Valeur entre 1 et 3
                }
                else
                {
                    randomValue = Random.Range(1, 11); // Valeur aléatoire de 1 à 10
                }
            }

            // Met à jour le texte
            text.text = $"{randomSymbol} {randomValue}";
        }

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
