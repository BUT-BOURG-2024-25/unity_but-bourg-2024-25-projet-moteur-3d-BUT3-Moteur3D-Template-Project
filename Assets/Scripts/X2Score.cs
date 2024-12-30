using System.Collections;
using UnityEngine;

public class DoubleScorePowerUp : MonoBehaviour
{
    public float doubleScoreDuration = 5f; // Durée du doublement du score en secondes

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée avec : " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision avec un joueur détectée.");
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null && playerController.playerManager != null)
            {
                Debug.Log("PlayerManager trouvé via PlayerController, activation du doublement du score.");
                playerController.playerManager.ActivateDoubleScore(doubleScoreDuration);
            }
            else
            {
                Debug.LogWarning("PlayerManager ou PlayerController introuvable !");
            }

            Destroy(gameObject); // Détruit l'objet power-up après collision
        }
        else
        {
            Debug.LogWarning("Collision avec un objet non joueur : " + other.tag);
        }
    }
}