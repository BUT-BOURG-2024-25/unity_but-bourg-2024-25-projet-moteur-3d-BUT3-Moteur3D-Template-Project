using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countSoldat : Singleton<countSoldat>
{
    [SerializeField]
    private TextMeshProUGUI soldatCountText;

    private int soldatCount;
    private GameManager gameManager; // R�f�rence au GameManager

    void Start()
    {
        // R�cup�rer la r�f�rence du GameManager
        gameManager = GameObject.FindObjectOfType<GameManager>();

        CountSoldats();
    }

    void Update()
    {
        CountSoldats();

        // Si le nombre de soldats atteint 0, d�clencher la fin de la partie
        if (getNombreSoldat() == 0)
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }

    private void CountSoldats()
    {
        soldatCountText.text = getNombreSoldat().ToString();
    }

    public int getNombreSoldat()
    {
        soldatCount = 0;
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Soldat"))
            {
                soldatCount++;
            }
        }
        return soldatCount;
    }
}
