using UnityEngine;

public class AutoMoveSenser : MonoBehaviour
{
    public float DodgeAmount;


    void Update()
    {
        
    }
    public void AutoMove()
    {
        // 적이 스폰될 때마다 배열한다.--> 업데이트때 마다 배열을 계속 찾는데 뭔가 배열값을 못찾아서 오류가 난다.
        GameObject[] EnemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemyObjects.Length == 0) return;
        Vector2 enemyVector = EnemyObjects[_enemyNumber].transform.position;
        Vector2 playerVector = transform.position;
        Vector2 distance = playerVector - enemyVector;

        // 
        Vector2 DodgeVector = new Vector2(DodgeAmount, 0);

       
        Vector2 autoPosition = transform.position;
        Vector2 newAutoPosition = autoPosition + DodgeVector * Speed * Time.deltaTime;

        transform.position = newAutoPosition;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject[] EnemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemyObjects.Length == 0) return;
        Vector2 enemyVector = EnemyObjects[_enemyNumber].transform.position;
        Vector2 playerVector = transform.position;
        Vector2 distance = playerVector - enemyVector;
    }
}
