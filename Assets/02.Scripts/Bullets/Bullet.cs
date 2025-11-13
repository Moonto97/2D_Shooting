
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 목표 : 위로 계속 이동하고 싶다.

    // 필요 속성
    [Header("이동속력")]
    public float StartSpeed = 1f;   // 초기 속도
    private float _speed;   // 최종 속도
    [Header("가속도")]
    public float TargetSpeed = 7f;  // 목표 속도
    public float TargetTime = 1.2f;     // 목표 속도 도달까지 걸리는 시간 (초)
    [Header("데미지")]
    public float BulletDamage = 60f;

    

    void Start()
    {
        _speed = StartSpeed;
        
        
    }

    
    void Update()
    {
        
        float acceleration = (TargetSpeed - StartSpeed) / TargetTime; // 가속도 = (목표 속력 - 초기 속력) / 목표속력 달성까지 걸린 시간
        _speed += Time.deltaTime * acceleration;   // Time.deltaTime 시간 기반의 정확한 변화량 계산기라고 생각하면 편하다.
        _speed = Mathf.Min(_speed, TargetSpeed); // _speed 가 TargetSpeed 보다 커지면 TargetSpeed 로 고정
        // Mathf 어떤 속성과 어떤 메서드를 가지고 있는지 톺아볼 필요가 있다.


        Vector2 direction = Vector2.up; // 위 방향 벡터 방향 설정    == new Vector2(0,1);

        Vector2 position = transform.position;  // 현재 위치

        // 가속도를 준다 속도가 점점 TargetSpeed 까지 높아지는데 걸리는 시간 TargetTime 초
        // Time.deltaTime : 1초에 60프레임, 120프레임 등 프레임이 일정하지 않은 경우 프레임에 상관없이 1초 동안의 시간을 일정하게 맞춰주는 역할




        Vector2 newPosition = position + direction * _speed * Time.deltaTime; // 새로운 위치 = 현재 위치 + 방향 벡터 * 속력 * 시간
        transform.position = newPosition; // 위치 업데이트


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag ("Enemy")) return;

        Enemy enemy = other.GetComponent<Enemy>();  // 충돌한 상대방 오브젝트의 Enemy 컴포넌트를 가져온다.
        enemy.Hit(BulletDamage);  // 상대방 오브젝트의 Hit 메서드를 호출하면서 데미지 값을 전달한다.
        

        // GetComponent 는 게임 오브젝트에 붙어있는 컴포넌트를 가져올 수 있다.


        this.gameObject.SetActive(false);   // this.gameObject 이 스크립트를 가지고 있는 오브젝트를 뜻함
        
        
        // 객체 간의 상호작용을 할 때 묻지말고 시켜라.
    }

    

}
