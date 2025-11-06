using UnityEngine;

public class EnemyTrace : MonoBehaviour
{
    [Header("스텟")]
    float MoveSpeed = 2f;
    private float _health = 100f;
    public float EnemyDamage = 1f;
    GameObject playerObject;

    private void Start()
    {
          // 캐싱 : 자주 쓰는 데이터를 미리 가까운 곳에 저장해두고 참조하는 것.
    }


    void Update()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Vector2 playerPosition = playerObject.transform.position;

        Vector2 enemyPosition = transform.position;
        Vector2 enemyDirection = (playerPosition - enemyPosition).normalized;
        transform.Translate(enemyDirection * MoveSpeed * Time.deltaTime);


        // 플레이어의 포지션을 불러와서
        // 포지션 방향으로 실시간 이동하도록 한다.
        // 단순히 플레이어의 벡터값을 가져오는 것이 아니고
        // 플레이어의 좌표값을 가져와서 그것을 방향벡터로 구현해야 할 것 같다.

        // 내 위치에서 플레이어의 위치를 뺀다?

        

    }

    public void Hit(float damage)
    {
        _health -= damage;
        if (_health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth.Hit(EnemyDamage);    // 플레이어의 Hit 메서드를 호출하고 데미지 값을 전달한다.

    }
}
