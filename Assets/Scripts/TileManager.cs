using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    
    public GameObject[] tilePrefabs;

    public float zSpawn = 0;

    public float tileLength = 30;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;
    public int numberOfTiles = 10;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTiles(0);
            }
            else
            {
                SpawnTiles(Random.Range(0, tilePrefabs.Length));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTiles(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTiles(int tileIndex)
    {
        Vector3 spawnPosition = new Vector3(0, 0, zSpawn); // Aligner sur l'axe Z
        GameObject go = Instantiate(tilePrefabs[tileIndex], spawnPosition, Quaternion.identity); // Pas de rotation inutile
        activeTiles.Add(go);
        zSpawn += tileLength; // Avancer de la longueur exacte de la tuile
    }


    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
