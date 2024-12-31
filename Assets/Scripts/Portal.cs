using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    public Renderer portalRender;
    [SerializeField]
    public TextMeshPro portalText;
    [SerializeField]
    public Material redMaterial; // Mat�riau rouge
    [SerializeField]
    public Material blueMaterial; // Mat�riau bleu

    public int portalsValue = 0;
    public string portalCalcul = "";

    // Start is called before the first frame update
    void Start()
    {
        Material randomMaterial = null;

        randomMaterial = Random.value > 0.5f ? redMaterial : blueMaterial;

        portalRender.material = randomMaterial;
        
        // Configure le texte
        if (portalText != null)
        {
            // G�n�re un symbole et une valeur
            string[] symbols = { "-", "+", "x" };
            string randomSymbol;
            int randomValue;

            if (randomMaterial == redMaterial)
            {
                randomSymbol = symbols[0];
                randomValue = Random.Range(1, 11); // Valeur entre 1 et 10
                portalCalcul = randomSymbol;
                portalsValue = randomValue;
            }
            else
            {
                randomSymbol = symbols[Random.Range(1, 3)];
                if (randomSymbol == "x")
                {
                    randomValue = Random.Range(1, 4); // Valeur entre 1 et 3
                    portalCalcul = randomSymbol;
                    portalsValue = randomValue;
                }
                else
                {
                    randomValue = Random.Range(1, 11); // Valeur al�atoire de 1 � 10
                    portalCalcul = randomSymbol;
                    portalsValue = randomValue;
                }
            }

            // Met � jour le texte
            portalText.text = $"{randomSymbol} {randomValue}";
        }
    }

    public string getPortalAction()
    {
        return $"{portalCalcul},{portalsValue}";
    }
}
