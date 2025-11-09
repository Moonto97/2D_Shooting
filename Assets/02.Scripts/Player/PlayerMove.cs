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
    


    private void Start()
    {
       

    }


    private void Update()
    {
        // 1. 키보드 입력을 감지한다.
        // 유니티에서는 Input 이라고 하는 모듈이 입력에 관한 모든 것을 담당한다.
        float h = Input.GetAxis("Horizontal");  // 수평 입력에 대한 값을 -1~1로 가져온다.
        float v = Input.GetAxis("Vertical");    // 수평 입력에 대한 값을 -1~1로 가져온다.

        

        // 2. 입력으로부터 방향을 구한다.
        // 벡터 : 크기와 방향을 표현하는 물리 개념
        Vector2 direction = new Vector2(h, v);
        direction.Normalize(); // 방향 벡터를 정규화(크기를 1로 맞춤)


        // 3. 그 방향으로 이동을 한다.
        Vector2 position = transform.position; // 현재 위치
        // 새로운 위치 = 현재 위치 + 방향 * 속력 * 시간
        // 새로운 위치 = 현재 위치 + 속도 * 시간 // 속도 = 방향 * 속력

        
        

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = ShiftSpeed * Speed;
            
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = Speed / ShiftSpeed;
        }






        //       새로운위치    현재 위치     방향
        Vector2 newPosition = position + direction * Speed * Time.deltaTime;    // 새로운 위치


        // Time.deltaTime : 이전 프레임으로부터 현재 프레임까지 시간이 얼마나 흘렀는지.. 나타내는 값
        //                  = 1초 / fps 값과 비슷하다. 프레임이 다르면 게임 속도가 달라지는 현상을 막기 위해 사용한다.

        // 이동속도 10
        // 컴퓨터 1 : 50fps : Update -> 초당 50 실행   -> 10 * 50 = 500    * Time.deltaTime (두 개의 값을 같아지게 하는 수)
        // 컴퓨터 2 : 100fps : Update -> 초당 100 실행 -> 10 * 100 = 1000  * Time.deltaTime

        // 포지션 값에 제한을 준다.
        // 맨 마지막에 있는 newPosition 값을 갱신하는 함수가 아래 식 위에 있어서 처음에 의도대로 움직여지지 않았다.
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
        transform.position = newPosition;    // 새로운 위치로 갱신

        
        


    }



    // tranlate 방식 이동
    // mathf 방식으로 이동제한, 속도 조절까지 가능 하다 한번씩 해볼 것

    public void SpeedUp(float value)
    {
        Speed += value;
        if (Speed >= MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    
    public void EnemyCounter(int takeCount) // 삭제할때는 EnemySpawner 의 관련코드도 지우자,,,
    {
        // EnemySpawner 에서 몇번째 적인지 번호를 받아왔다. (지역변수로.)
        _enemyNumber = takeCount;

    }

    void AutoMove()
    {
        // 적이 스폰될 때마다 배열한다.--> 업데이트때 마다 배열을 계속 찾는데 뭔가 배열값을 못찾아서 오류가 난다.
        GameObject[] EnemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemyObjects.Length == 0) return;
        Vector2 enemyVector = EnemyObjects[0].transform.position;
        Vector2 playerVector = transform.position;
        Vector2 distance = playerVector - enemyVector;

        // 
        Vector2 DodgeVector = new Vector2(DodgeAmount, 0);


        if (distance.magnitude < DodgeLimit)
        {
            Vector2 autoPosition = transform.position;
            Vector2 newAutoPosition = autoPosition + DodgeVector * Speed * Time.deltaTime;

            transform.position = newAutoPosition;

        }


    }

}
