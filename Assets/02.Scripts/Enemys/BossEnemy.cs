using UnityEngine;
using UnityEngine.UIElements;

public class BossEnemy : MonoBehaviour
{
    [Header("스텟")]
    public float MoveSpeed = 2f;
    private float _health = 500f;
    private float _maxHealth = 500;
    private float _bossDamage = 2f;
    [Header("폭발프리펩")]
    public GameObject ExplisionPrefab;
    [Header("점수")]
    private int Score = 500;
    [Header("폭발SFX")]
    public AudioClip BossDeathSound;
    [Header("애니메이터")]
    private Animator _animator;

    private GameObject _enemySpawner;
    // 공격 구현 예정
    private void Start()
    {
        _animator = GetComponent<Animator>();    // 캠퍼스가서 애니메이션 삽입.
        _enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        Vector3 enemySpawnerPosition = _enemySpawner.transform.position;
        transform.position = enemySpawnerPosition;
    }

    private void Update()
    {
        // 원점으로 이동시킨다. 일정 스코어 달성 시 << 등장조건: 스코어매니저에서 호출해서 스폰하도록 설정
        MoveZero();

    }
    private void MoveZero() 
    {
        Vector2 vector = (Vector3.zero - transform.position).normalized;
        transform.Translate(vector * MoveSpeed * Time.deltaTime);

    }

}
