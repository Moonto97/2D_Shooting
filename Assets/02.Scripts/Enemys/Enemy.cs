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

    [Header("아이템")]
    public GameObject HealthItemPrefab;
    public GameObject FireRateItemPrefab;
    public GameObject MoveSpeedItemPrefab;
    private int _healthDropRate = 70;
    private int _moveSpeedDropRate = 20;
    private int _fireRateDropRate = 10;

    [Header("템드랍율")]
    public float EnemyDropRate = 50f;

    [Header("폭발이펙트프리펩")]
    public GameObject ExplosionPrefab;

    [Header("애니메이터")]
    private Animator _animator;

    [Header("적1마리당 점수")]
    private int Score = 100;

    [Header("폭발SFX")]
    public AudioClip EnemyDeathSound;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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

    private void MoveDirectional() // 직선 이동 타입
    {
        Vector2 direction = Vector2.down.normalized; // ==new Vector2(0, -1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }

    private void MoveTrace()    // 추격 이동 타입
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Vector2 playerPosition = playerObject.transform.position;
        Vector2 enemyPosition = transform.position;
        Vector2 enemyDirection = (playerPosition - enemyPosition).normalized;

        float angle = Mathf.Atan2(enemyDirection.y, enemyDirection.x) * Mathf.Rad2Deg;
        angle += 90f;
        transform.rotation = Quaternion.Euler (0f, 0f, angle);
        transform.Translate(enemyDirection* MoveSpeed * Time.deltaTime);

    }



    // 만약 헬스값이 "변화"하면 Idle -> EnemyTHit, EnemyDHit 의 트리거가 되도록 한다
    // 트리거 발동 후 1초 지나면 다시 Idle로 돌아가도록 설정한다.

    public void Hit(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("Hit");  // 애니메이터에 Hit 트리거 실행
        if (_health <= 0f)
        {
            Death();
        }     
    }

    private void Death()
    {
        MakeExplosionEffect();

        GameObject audioObject = new GameObject("EDeathObject");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = EnemyDeathSound;
        audioSource.Play();
        Destroy(audioObject, EnemyDeathSound.length);
        // enemy가 파괴되면서 소리도 함께 사라지므로
        // audioObject 라는 가상의 오브젝트를 새로 메모리에 생성한 후 
        // AudioSource 컴포넌트를 생성한 오브젝트에 넣어줌
        // audioSource.clip 이 뭔지 알려준다음
        // 플레이
        // 오디오의 길이만큼 플레이한 후 파괴하도록 설정.

        Destroy(this.gameObject);
        int randomNumber = Random.Range(1, 100);
        if (randomNumber <= EnemyDropRate)
        {
            DropItem(Random.Range(1, _healthDropRate + _moveSpeedDropRate + _fireRateDropRate));
        }
        
        // 응집도를 높여라
        // 응집도 : 데이터와 데이터를 조작하는 로직이 얼마나 잘 모여있냐??
        // 응집도를 높이고, 필요한 것만 외부에 공개하는 것을 '캡슐화' 라고 한다.
        
        ScoreManager.Instance.AddScore(Score);     // 싱글톤.
                                                   // 스코어매니저로의 전역적인 접근 가능
                                                   // 굳이 게임오브젝트를 찾고 컴포넌트를 불러오지 않아도
                                                   // ScoreManager.Instance 로 접근

        // 관리자는 인스턴스가 단 하나다. 혹은 단 하나임을 보장해야 한다.
        // 아무대서나 빠르게 접근하고 싶다.
        // 싱글톤 패턴

    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth.Hit(EnemyDamage);    // 플레이어의 Hit 메서드를 호출하고 데미지 값을 전달한다.

    }

    // 죽을 때 아이템 드랍
    private void DropItem(int randomDrop)
    {
        if (randomDrop <= _healthDropRate)
        {
            GameObject healthItem = Instantiate(HealthItemPrefab);
            healthItem.transform.position = transform.position;
        }
        else if (randomDrop <= _healthDropRate + _moveSpeedDropRate)
        {
            GameObject moveSpeedItem = Instantiate(MoveSpeedItemPrefab);
            moveSpeedItem.transform.position = transform.position;
        }
        else
        {
            GameObject fireRateItem = Instantiate(FireRateItemPrefab);
            fireRateItem.transform.position = transform.position;
        }

    }

    private void MakeExplosionEffect()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    }

}
