using UnityEngine;

public class EnemyTrace : MonoBehaviour
{
    [Header("이동")]
    public float MoveSpeed = 2f;
    

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PlayerMove playerMove = player.GetComponent<PlayerMove>();
        Vector2 playerPosition = player.transform.position;

        Vector2 enemyDirection = playerPosition;
        transform.Translate(enemyDirection * MoveSpeed * Time.deltaTime);








    }
}
