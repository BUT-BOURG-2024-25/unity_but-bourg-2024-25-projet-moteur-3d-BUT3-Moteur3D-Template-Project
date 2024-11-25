using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public Transform target;
    public float followSpeed = 2f;
    public GameObject enemyPrefab;
    public int initialEnemyCount = 2;
    public float spawnInterval = 5f;
    private int enemyCount;
    void Start()
    {
        enemyCount = initialEnemyCount;
        StartCoroutine(SpawnEnemies());
        //foreach (Transform child in transform)
        //{
        //    enemies.Add(child.gameObject);
        //}
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
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = CalculatePyramidPosition(i, enemyCount);
                GameObject newEnemy = Instantiate(enemyPrefab, transform);
                newEnemy.transform.localPosition = spawnPosition;
                enemies.Add(newEnemy);
            }

            Debug.Log($"Spawned {enemyCount} enemies in EnemyGroup");
            enemyCount++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 CalculatePyramidPosition(int index, int totalEnemies)
    {
        int row = Mathf.CeilToInt((Mathf.Sqrt(8 * index + 1) - 1) / 2); 
        int enemiesInRow = row; 
        int positionInRow = index - (row * (row - 1)) / 2; 
        float spacing = 2f;

        return new Vector3(
            (positionInRow - (enemiesInRow - 1) / 2f) * spacing,
            0,
            -row * spacing
        );
    }
}
