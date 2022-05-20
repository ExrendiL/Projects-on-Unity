using UnityEngine;

public class DeletePlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Destroy(other.gameObject);
        }
    }
}
