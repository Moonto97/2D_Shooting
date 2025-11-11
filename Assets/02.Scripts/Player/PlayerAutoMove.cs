using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAutoMove : MonoBehaviour
{
    private Player _player;
    private float DetectingZoneSize = 2;
    private void Start()
    { 
        _player = GetComponent<Player>();
    }


    public void Execute()
    {
        // 1. 모든 적을 찾는다.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        
        if (enemies == null || enemies.Length == 0)
        {
            transform.Translate(-transform.position * _player.Speed * Time.deltaTime);
            return;
        }
        // 2. 가장 가까운 적을 찾는다.
        GameObject closestEnemy = enemies[0];
        Vector2 closestVector = closestEnemy.transform.position;
        float closestDistance = Vector2.Distance(closestVector, transform.position);
        for (int i = 1; i < enemies.Length; i++)
        {
            float distance = Vector2.Distance(transform.position, enemies[i].transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemies[i];
            }
        }
        closestVector = closestEnemy.transform.position;

        if (closestDistance < DetectingZoneSize)
        {
            // 3. 왼쪽이면 왼쪽
            Vector2 playerPosition = transform.position;
            Vector2 direction = Vector2.zero;
            if (closestVector.x < playerPosition.x)
            {
                direction.x = 1;
            }
            // 4. 오른쪽이면 오른쪽
            if (closestVector.x > playerPosition.x)
            {
                direction.x = - 1;
            }
            // 5. 위 로직에 따라 이동.
            transform.Translate(direction * _player.Speed * Time.deltaTime);
        }

        

    }
}
