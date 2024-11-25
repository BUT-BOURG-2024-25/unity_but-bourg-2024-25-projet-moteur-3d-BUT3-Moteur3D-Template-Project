using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public Transform target;
    public float followSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            enemies.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position+=direction*followSpeed*Time.deltaTime;
        }
        if(enemies.Count == 0)
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
