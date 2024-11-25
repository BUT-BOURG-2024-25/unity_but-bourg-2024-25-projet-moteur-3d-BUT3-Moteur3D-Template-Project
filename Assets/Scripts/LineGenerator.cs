using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject solPrefab; // Le préfab du sol
    public int numberOfSegments = 0; // Nombre de segments de sol à générer
    public float segmentLength = 20f; // Longueur de chaque segment

    void Start()
    {
        GenerateLine(Vector3.zero); // Appelle la fonction pour générer la ligne de sol
    }

    void GenerateLine(Vector3 startPosition)
    {
        // Calculer la largeur du sol à partir de solPrefab (en Z)
        float solLenght = solPrefab.GetComponent <Renderer>().bounds.size.z;

        for (int i = 0; i < numberOfSegments; i++)
        {
            // Calcule la position du segment de sol
            Vector3 position = startPosition + new Vector3(0, 0, i * solLenght); // Inclut la largeur du sol en Z

            // Crée le segment de sol
            Instantiate(solPrefab, position, Quaternion.identity);
        }
    }
}
