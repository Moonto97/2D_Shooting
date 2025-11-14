using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
