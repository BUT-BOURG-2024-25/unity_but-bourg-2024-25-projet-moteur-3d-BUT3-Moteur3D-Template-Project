using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countSoldat : MonoBehaviour
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
        soldatCount = 0;
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Soldat"))
            {
                soldatCount++;
            }
        }
        soldatCountText.text = soldatCount.ToString();
    }
}
