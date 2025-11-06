using UnityEngine;

// Enum : 열거형 : 기억하기 어려운 상수들을 기억하기 쉬운 이름 하나로 묶어 관리하는 표현 방식
public enum EEnemyType
{
    Directional, // 0
    Trace        // 1
}


public class Enemy : MonoBehaviour
{
    [Header("스텟")]
    public float MoveSpeed = 5f;
    private float _health = 100f;
    public float EnemyDamage = 1f;

    [Header("적 타입")]
    public EEnemyType Type;
    private void Update()
    {

        // 두가지 타입
        if(Type == EEnemyType.Directional)
        {
            MoveDirectional();
        }

        if(Type == EEnemyType.Trace)
        {
            MoveTrace();
        }

        // 타입을 조건문으로 분기하기 보다는
        // 0. Enemy 클래스 안에서 함수로 쪼개자.
        // or
        // 1. 클래스로 쪼개는게 좋다.
        // or
        // 2. 쪼개고 나니까 똑같은 기능/속성이 있네 -> 상속
        // 상속을 하자니 하는 일이 너무 많고, ---> 조합
        // 재현씨 코드가 강사님이 의도한 조합을 잘 이용한 케이스니 참고해보자 -> 슬렉 11.06 실습과제 댓글에 깃주소 있음.
            

    }

    private void MoveDirectional()
    {
        Vector2 direction = Vector2.down.normalized; // ==new Vector2(0, -1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }

    private void MoveTrace()
    {
    GameObject playerObject = GameObject.FindWithTag("Player");
    Vector2 playerPosition = playerObject.transform.position;
    Vector2 enemyPosition = transform.position;

    Vector2 enemyDirection = (playerPosition - enemyPosition).normalized;
    transform.Translate(enemyDirection* MoveSpeed * Time.deltaTime);
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
