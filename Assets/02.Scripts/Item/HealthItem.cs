using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public float HealAmount = 1f;
    private float _time;
    private float _startTrace = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        playerHealth.Heal(HealAmount);
        Destroy(this.gameObject);

    }

}
