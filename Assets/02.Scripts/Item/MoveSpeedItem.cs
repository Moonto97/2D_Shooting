using UnityEngine;

public class MoveSpeedItem : MonoBehaviour
{
    public float SpeedBoostAmount = 1f;

    private float _time;
    private float _startTrace = 2f;
    public float TraceSpeed = 4f;

    void Start()
    {
        
    }

    
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _startTrace)  // 플레이어 추격
        {
            MoveTrace();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        PlayerMove playerMove = other.gameObject.GetComponent<PlayerMove>();
        playerMove.SpeedUp(SpeedBoostAmount);
        Destroy(this.gameObject);

    }

    private void MoveTrace()    // 추격 이동 타입
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Vector2 playerPosition = playerObject.transform.position;
        Vector2 itemPosition = transform.position;

        Vector2 itemDirection = (playerPosition - itemPosition).normalized;
        transform.Translate(itemDirection * TraceSpeed * Time.deltaTime);
    }

}
