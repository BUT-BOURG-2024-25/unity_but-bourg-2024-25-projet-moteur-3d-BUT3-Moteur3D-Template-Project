using UnityEngine;

public class FlecheTrap : MonoBehaviour
{
    public GameObject arrowPrefab;
    public int rows = 3; // Nombre de rang�es
    public int cols = 3; // Nombre de colonnes
    public float arrowSpacing = 1f; // Espacement entre les fl�ches
    public float speedMin = 3f; // Vitesse minimale pour chaque groupe de fl�ches
    public float speedMax = 5f; // Vitesse maximale pour chaque groupe de fl�ches

    public float startY = -1f; // Position de d�part
    public float maxY = 1f; // Hauteur maximale
    public float minY = -2f; // Hauteur minimale

    private GameObject[] arrows; // Liste des fl�ches
    private float groupSpeed; // Vitesse unique pour ce groupe

    private Vector3 positionOffset = new Vector3(-1f, 3, 10f);

    void Start()
    {
        groupSpeed = Random.Range(speedMin, speedMax);

        transform.position += positionOffset;

        SpawnArrows();
    }

    void Update()
    {
        MoveArrows();
    }

    // G�n�re les fl�ches
    void SpawnArrows()
    {
        arrows = new GameObject[rows * cols];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3 position = new Vector3(
                    transform.position.x + i * arrowSpacing,
                    startY,
                    transform.position.z + j * arrowSpacing
                );

                GameObject arrow = Instantiate(arrowPrefab, position, Quaternion.identity);
                arrows[index] = arrow;
                index++;
            }
        }
    }

    // D�place les fl�ches de haut en bas
    void MoveArrows()
    {
        foreach (GameObject arrow in arrows)
        {
            if (arrow != null)
            {
                Vector3 newPosition = arrow.transform.position;
                newPosition.y += groupSpeed * Time.deltaTime;

                if (newPosition.y > maxY)
                {
                    groupSpeed = -Mathf.Abs(groupSpeed); // Fait descendre les fl�ches
                }
                else if (newPosition.y < minY)
                {
                    groupSpeed = Mathf.Abs(groupSpeed); // Fait monter les fl�ches
                }

                arrow.transform.position = newPosition;
            }
        }
    }

    public void DestroyArrows()
    {
        if (arrows != null)
        {
            foreach (GameObject arrow in arrows)
            {
                if (arrow != null)
                {
                    Destroy(arrow);
                }
            }
        }
    }
}
