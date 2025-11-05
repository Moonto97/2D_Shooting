using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("스텟")]
    float MoveSpeed = 2f;
    private float _health = 100f;
    public float EnemyDamage = 1f;
    private void Update()
    {
        Vector2 direction = Vector2.down; // ==new Vector2(0, -1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);

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
