using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
   
    void Start()
    {
        health = 3f;
    }


    void Update()
    {
        if (health <= 0f)
        {
            
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (!other.gameObject.CompareTag("Enemy")) return;  // other.gameObject.name 으로 하는 것은 위험. tag 로 구분하는 것이 더 안전
        Destroy(other.gameObject);  // 충돌한 적 오브젝트 파괴
        health -= 1f;   // 적과 충돌 시 체력 1 감소
        


    }




}

