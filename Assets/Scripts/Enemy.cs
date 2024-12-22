using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ally"))
        {
            Ally ally = collision.gameObject.GetComponent<Ally>();
            if (ally != null)
            {
                ally.Die();
            }
        }
    }

    public void Die()
    {
        EnemyGroup group = GetComponentInParent<EnemyGroup>();
        if (group != null)
        {
            group.RemoveEnemy(gameObject);
        }
        Destroy(gameObject);
    }
}
