using UnityEngine;
using UnityEngine.UIElements;

public class BossEnemy : MonoBehaviour
{
    [Header("스텟")]
    public float MoveSpeed = 2f;
    private float _health = 1000f;
    private float _bossDamage = 2f;
    [Header("점수")]
    private int Score = 500;
    [Header("애니메이터")]
    private Animator _animator;
    private Vector3 BossPosition = new Vector3(0f, 4f, 0f);
    [Header("사운드")]
    public AudioClip BossDeathSound;
    [Header("폭발이펙트")]
    public GameObject ExplosionEffect;

    private PlayerHealth _playerHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>(); 
        Vector3 bossPosition = transform.position;
        GameObject player = GameObject.FindWithTag("Player");
        _playerHealth = player.GetComponent<PlayerHealth>();
        
    }

    private void Update()
    {
        
        Move();

    }
    private void Move() 
    {
        Vector2 vector = (BossPosition - transform.position).normalized;
        transform.Translate(vector * MoveSpeed * Time.deltaTime);

    }
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

        GameObject audioObject = new GameObject("BDeathObject");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = BossDeathSound;
        audioSource.Play();
        Destroy(audioObject, BossDeathSound.length);

        
        _animator.SetTrigger("Idle");
        Destroy(this.gameObject);
        
        ScoreManager.Instance.AddScore(Score);     
    }
    private void MakeExplosionEffect()
    {
        Vector3 explosionPosition = new Vector3(1f, 0, 0);
        GameObject bossExplosion = Instantiate(ExplosionEffect, BossPosition, Quaternion.identity);
        GameObject bossExplosion2 = Instantiate(ExplosionEffect, BossPosition + explosionPosition, Quaternion.identity);
        GameObject bossExplosion3 = Instantiate(ExplosionEffect, BossPosition - explosionPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth.Hit(_bossDamage);
    }
}
