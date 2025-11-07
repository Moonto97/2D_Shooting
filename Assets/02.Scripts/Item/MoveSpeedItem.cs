using UnityEngine;

public class MoveSpeedItem : MonoBehaviour
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
        if (!other.gameObject.CompareTag("Player")) return;
        PlayerMove playerMove = other.gameObject.GetComponent<PlayerMove>();
        playerMove.SpeedUp(SpeedBoostAmount);
        Destroy(this.gameObject);

    }

}
