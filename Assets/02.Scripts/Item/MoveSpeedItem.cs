using UnityEngine;

public class MoveSpeedItem : MonoBehaviour
{
    public float SpeedBoostAmount = 1f;

    private float _time;
    private float _startTrace = 2f;
    public float TraceSpeed = 4f;
    private Player _player;
    public GameObject ConsumeEffect;
    public AudioClip ItemSFX;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        SFXObject();
        Destroy(this.gameObject);
        float randomDegree = Random.Range(0, 359);
        Instantiate(ConsumeEffect, _player.transform.position, Quaternion.Euler(0, 0, randomDegree));
    }

    private void MoveTrace()    // 추격 이동 타입
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Vector2 playerPosition = playerObject.transform.position;
        Vector2 itemPosition = transform.position;

        Vector2 itemDirection = (playerPosition - itemPosition).normalized;
        transform.Translate(itemDirection * TraceSpeed * Time.deltaTime);
    }

    private void SFXObject()
    {
        // SFX
        GameObject audioObject = new GameObject("ItemSFX");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = ItemSFX;
        audioSource.Play();
        Destroy(audioObject, ItemSFX.length);
    }

}
