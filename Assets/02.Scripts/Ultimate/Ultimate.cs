using UnityEngine;

public class Ultimate : MonoBehaviour
{
    private float UltTimer;
    private float TimeLimit = 3f;
    private float UltDamage = float.MaxValue;
    private void Update()
    {
        // 3초 후 삭제
        UltTimer += Time.deltaTime;
        if( UltTimer > TimeLimit )
        {
            Destroy(this.gameObject);
        }
        // 적과 닿으면 적 체력에 데미지 전달
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.Hit(UltDamage);
    }
}
