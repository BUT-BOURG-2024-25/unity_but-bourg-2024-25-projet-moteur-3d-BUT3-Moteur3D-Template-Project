using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public Transform target;
    public float followSpeed = 2f;
    void Start()
    {
        foreach (Transform child in transform)
        {
            enemies.Add(child.gameObject);
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }

        if (enemies.Count == 0)
        {
            Destroy(gameObject);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy);
    }
}
