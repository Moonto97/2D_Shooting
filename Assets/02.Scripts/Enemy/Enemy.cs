using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("스텟")]
    float MoveSpeed = 2f;
    private float _health = 100f;
    private float GenTimeInterval = 3f;
    private void Update()
    {
        Vector2 direction = Vector2.down; // ==new Vector2(0, -1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);


    }

    



}
