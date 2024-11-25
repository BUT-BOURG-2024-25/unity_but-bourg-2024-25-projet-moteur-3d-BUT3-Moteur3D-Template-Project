using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static bool GameOver;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        
    }
}
