
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float followSpeed = 7f; // Vitesse individuelle de l'ennemi
    private Vector3 targetPosition; // Position cible assign�e par le EnemyGroup

    void Update()
    {
        // Si une position cible est d�finie, se d�placer vers cette position
        if (targetPosition != Vector3.zero)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }

    // Mise � jour de la position cible par le EnemyGroup
    public void UpdateTarget(Vector3 newTargetPosition)
    {
        targetPosition = newTargetPosition;
    }

    // Gestion des collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soldat"))
        {
            // D�truire le soldat touch�
            Destroy(collision.gameObject);

            // Supprimer cet ennemi du groupe
            EnemyGroup enemyGroup = transform.parent.GetComponent<EnemyGroup>();
            if (enemyGroup != null)
            {
                enemyGroup.RemoveEnemy(gameObject);
            }

            // D�truire l'ennemi lui-m�me
            Destroy(gameObject);

            // Optionnel : Ajouter des effets visuels/sonores
            Debug.Log("Collision : Soldat et ennemi d�truits !");
        }
    }
}