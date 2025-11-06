using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

}
