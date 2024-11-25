using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countSoldat : Singleton<countSoldat>
{
    [SerializeField]
    private TextMeshProUGUI soldatCountText;

    private int soldatCount;

    // Start is called before the first frame update
    void Start()
    {
        CountSoldats();
    }

    // Update is called once per frame
    void Update()
    {
        CountSoldats();
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
