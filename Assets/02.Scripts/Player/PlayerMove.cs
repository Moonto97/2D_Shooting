using Unity.VisualScripting;
using UnityEngine;
// 플레이어 이동
public class PlayerMove : MonoBehaviour
{
    [Header("능력치")]
    public float Speed = 0.2f;
    public float MaxSpeed = 15f;
    public float MinSpeed = 1f;
    public float SpeedAmount = 0.05f;
    public float ShiftSpeed = 1.2f; // 원래 속도에 곱할 수
    [Header("이동 범위")]   
    public float MaxX = 2.25f;
    public float MinX = -2.25f;
    public float MaxY = 5f;
    public float MinY = -5f;


    private void Start()
    {
        // 목표
        // 키보드 입력에 따라 방향을 구하고, 그 방향으로 이동시키고 싶다.

        // 구현 순서
        // 1. 키보드 입력
        // 2. 방향 구하는 방법
        // 3. 이동

    }


    private void Update()
    {
        // 1. 키보드 입력을 감지한다.
        // 유니티에서는 Input 이라고 하는 모듈이 입력에 관한 모든 것을 담당한다.
        float h = Input.GetAxis("Horizontal");  // 수평 입력에 대한 값을 -1~1로 가져온다.
        float v = Input.GetAxis("Vertical");    // 수평 입력에 대한 값을 -1~1로 가져온다.

        Debug.Log($"h:{h}, v :{v}");

        // 2. 입력으로부터 방향을 구한다.
        // 벡터 : 크기와 방향을 표현하는 물리 개념
        Vector2 direction = new Vector2(h, v);
        direction.Normalize(); // 방향 벡터를 정규화(크기를 1로 맞춤)

        Debug.Log($"direction : {direction.x}, {direction.y}");

        // 3. 그 방향으로 이동을 한다.
        Vector2 position = transform.position; // 현재 위치
        // 새로운 위치 = 현재 위치 + 방향 * 속력 * 시간
        // 새로운 위치 = 현재 위치 + 속도 * 시간 // 속도 = 방향 * 속력

        // Q,E 풀다운 시 Speed 에 SpeedAmount 값을 더하거나 빼준다.
        // 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed += SpeedAmount;

            if (Speed >= MaxSpeed)
            {
                Speed = MaxSpeed;
            }
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            Speed -= SpeedAmount;

            if (Speed <= MinSpeed)
            {
                Speed = MinSpeed;
            }
        }

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
        //                  = 1초 / fps 값과 비슷하다.

        // 이동속도 10
        // 컴퓨터 1 : 50fps : Update -> 초당 50 실행   -> 10 * 50 = 500    * Time.deltaTime (두 개의 값을 같아지게 하는 수)
        // 컴퓨터 2 : 100fps : Update -> 초당 100 실행 -> 10 * 100 = 1000  * Time.deltaTime

        // 포지션 값에 제한을 준다.
        // 맨 마지막에 있는 newPosition 값을 갱신하는 함수가 아래 식 위에 있어서 처음에 의도대로 움직여지지 않았다.
        if (newPosition.x >= MaxX)
        {
            newPosition.x = MinX;
        }
        else if (newPosition.x <= MinX)
        {
            newPosition.x = MaxX;
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
}
