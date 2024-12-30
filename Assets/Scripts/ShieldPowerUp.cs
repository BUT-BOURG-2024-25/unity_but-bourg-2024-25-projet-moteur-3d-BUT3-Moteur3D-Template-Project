using System.Collections;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 5f; // Durée du bouclier en secondes

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée avec : " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision avec un joueur détectée.");
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null && playerController.playerManager != null)
            {
                Debug.Log("PlayerManager trouvé via PlayerController, activation du bouclier.");
                playerController.playerManager.ActivateShield(shieldDuration);
            }
            else
            {
                Debug.LogWarning("PlayerManager ou PlayerController introuvable !");
            }

            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Collision avec un objet non joueur : " + other.tag);
        }
    }


}
