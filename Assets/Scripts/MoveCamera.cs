using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement de la caméra

    // Start is called before the first frame update
    void Start()
    {
        // Tu peux initialiser quelque chose ici si nécessaire
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacer la caméra en avant selon son orientation actuelle (localement)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
