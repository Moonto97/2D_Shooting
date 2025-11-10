using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
// 플레이어 이동
public class PlayerMove : MonoBehaviour
{
    [Header("능력치")]
    public float Speed = 5f;
    public float ShiftSpeed = 1.2f; // 원래 속도에 곱할 수
    public float MaxSpeed = 10f;

    [Header("이동 범위")]   
    public float MaxX = 2.25f;
    public float MinX = -2.25f;
    public float MaxY = 5f;
    public float MinY = -5f;

    private int _enemyNumber;
    
    public float DodgeLimit = 1.5f;
    public float DodgeAmount = 1f;
    
    Vector2 Distance;
    Vector2 traceDirection;




    private void Start()
    {
       

    }


    public void Update()
    {
        
        // 입력 받음
        float h = Input.GetAxis("Horizontal");  
        float v = Input.GetAxis("Vertical");   
        Vector2 direction = new Vector2(h, v);
        direction.Normalize(); 
        Vector2 position = transform.position; 
        

        
        
        // 스피드업
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = ShiftSpeed * Speed;
            
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = Speed / ShiftSpeed;
        }


        Vector2 newPosition = position + direction * Speed * Time.deltaTime;    // 새로운 위치

        // 포지션 제한
        if (newPosition.x >= MaxX)
        {
            newPosition.x = MaxX;
        }
        else if (newPosition.x <= MinX)
        {
            newPosition.x = MinX;
        }

        if (newPosition.y >= MaxY)
        {
            newPosition.y = MaxY;
        }
        else if (newPosition.y <= MinY)
        {
            newPosition.y = MinY;
        }
        transform.position = newPosition;


    }
    public void SpeedUp(float value)
    {
        Speed += value;
        if (Speed >= MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    
    

}
