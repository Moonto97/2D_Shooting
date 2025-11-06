using UnityEngine;

public class EnemyTrace : MonoBehaviour
{
    [Header("이동")]
    public float MoveSpeed = 4f;
    

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Vector2 playerPosition = player.transform.position;

        Vector2 enemyPosition = transform.position;
        Vector2 enemyDirection = (playerPosition - enemyPosition).normalized;
        transform.Translate(enemyDirection * MoveSpeed * Time.deltaTime);


        // 플레이어의 포지션을 불러와서
        // 포지션 방향으로 실시간 이동하도록 한다.
        // 단순히 플레이어의 벡터값을 가져오는 것이 아니고
        // 플레이어의 좌표값을 가져와서 그것을 방향벡터로 구현해야 할 것 같다.

        // 내 위치에서 플레이어의 위치를 뺀다?

        






    }
}
