using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    public void Update()
    {
        // 1. 모든 적을 찾는다.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 2. 가장 가까운 적을 찾는다.
        GameObject closestEnemy = enemies[0];
        for(int i = 1; i < enemies.Length; i++)
        {
            float distance = Vector2.Distance(transform.position, enemies[i].transform.position);
        }

        // 3. 왼쪽이면 왼쪽
        // 4. 오른쪽이면 오른쪽
        // 5. 적이 없다면 원점으로 이동
    }
}
