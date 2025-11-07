using UnityEngine;

public class Item : MonoBehaviour
{
    public float SpeedBoostAmount = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Item")) return;
        PlayerMove playerFire = other.gameObject.GetComponent<PlayerMove>();
        playerFire.Speed += SpeedBoostAmount;
        Destroy(this.gameObject);

    }

}
