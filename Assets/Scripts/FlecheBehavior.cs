using UnityEngine;

public class FlecheBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soldat"))
        {
            // D�truire le Soldat touch�
            Destroy(other.gameObject);
        }
    }
}
