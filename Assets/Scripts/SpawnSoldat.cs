
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Le prefab du joueur (groupSoldat)
    public float distanceFromCamera = 10f; // Distance devant la cam�ra pour faire appara�tre le joueur
    private GameObject currentPlayerInstance; // R�f�rence au joueur actuel

    // M�thode pour spawn le joueur
    public void SpawnPlayer()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Le prefab du joueur (groupSoldat) n'est pas assign� !");
            return;
        }

        if (currentPlayerInstance != null)
        {
            Destroy(currentPlayerInstance); // D�truire le joueur pr�c�dent s'il existe
        }

        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Aucune cam�ra principale n'a �t� trouv�e !");
            return;
        }

        // Position du spawn du joueur devant la cam�ra
        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCamera;
        spawnPosition.y = 0.5f; // Fixe la hauteur pour ne pas �tre sous le sol

        // Instancier le joueur
        currentPlayerInstance = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        currentPlayerInstance.name = "Player"; // Renomme l'objet instanci�
    }

    // M�thode � appeler au d�but de la partie ou apr�s un red�marrage
    public void InitializePlayer()
    {
        SpawnPlayer();
    }
}