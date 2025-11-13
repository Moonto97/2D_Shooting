using UnityEngine;

public class RightSubBullet : MonoBehaviour
{
    [Header("이동속력")]
    public float StartSpeed = 1f;   // 초기 속도
    private float _speed;   // 최종 속도
    [Header("가속도")]
    public float TargetSpeed = 4f;  // 목표 속도
    public float TargetTime = 1.2f;     // 목표 속도 도달까지 걸리는 시간 (초)
    [Header("발사각도")]
    public float Angle = 0.25f;
    [Header("데미지")]
    public float BulletDamage = 40f;

    public void Start()
    {
        _speed = StartSpeed;
    }

    public void Update()
    {
        float acceleration = (TargetSpeed - StartSpeed) / TargetTime; // 가속도 = (목표 속력 - 초기 속력) / 목표속력 달성까지 걸린 시간
        _speed += Time.deltaTime * acceleration;  
        _speed = Mathf.Min(_speed, TargetSpeed); // _speed 가 TargetSpeed 보다 커지면 TargetSpeed 로 고정

        Vector2 direction = new Vector2(Angle, 1f).normalized; // 방향 백터 설정

        Vector2 position = transform.position;  // 현재 위치


        
        Vector2 newPosition = position + direction * _speed * Time.deltaTime; // 새로운 위치 = 현재 위치 + 방향 벡터 * 속력 * 시간
        transform.position = newPosition; // 위치 업데이트
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        Enemy enemy = other.GetComponent<Enemy>();  // 충돌한 상대방 오브젝트의 Enemy 컴포넌트를 가져온다.
        enemy.Hit(BulletDamage);  // 상대방 오브젝트의 Hit 메서드를 호출하면서 데미지 값을 전달한다.

        this.gameObject.SetActive(false);
        
    }
}

