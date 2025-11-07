using UnityEngine;

public class FireRateItem : MonoBehaviour
{
    public float ReduceCoolTime = 0.1f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        PlayerFire playerFire = other.gameObject.GetComponent<PlayerFire>();
        playerFire.PowerUp(ReduceCoolTime);
        Destroy(this.gameObject);

    }

}
