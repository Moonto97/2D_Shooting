using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
    }

}
