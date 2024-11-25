using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        EnemyGroup group = GetComponentInParent<EnemyGroup>();
        if(group != null)
        {
            group.RemoveEnemy(gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ally"))
        {
            Ally ally = collision.gameObject.GetComponent<Ally>();
            if(ally != null)
            {
                ally.TakeDamage(gameObject);
            }
        }
    }
}
