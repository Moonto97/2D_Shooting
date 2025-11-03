using UnityEngine;
// 플레이어 이동
public class PlayerMove : MonoBehaviour
{
    public float Speed = 0.2f;
    
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

        Debug.Log($"direction : {direction.x}, {direction.y}");

        // 3. 그 방향으로 이동을 한다.
        Vector2 position = transform.position; // 현재 위치
        // 새로운 위치 = 현재 위치 + 방향 * 속력 * 시간
        // 새로운 위치 = 현재 위치 + 속도 * 시간 // 속도 = 방향 * 속력

        //       새로운위치    현재 위치     방향
        Vector2 newPosition = position + direction * Speed * Time.deltaTime;    // 새로운 위치
        transform.position = newPosition;    // 새로운 위치로 갱신

        // Time.deltaTime : 이전 프레임으로부터 현재 프레임까지 시간이 얼마나 흘렀는지.. 나타내는 값
        //                  = 1초 / fps 값과 비슷하다.

        // 이동속도 10
        // 컴퓨터 1 : 50fps : Update -> 초당 50 실행   -> 10 * 50 = 500    * Time.deltaTime (두 개의 값을 같아지게 하는 수)
        // 컴퓨터 2 : 100fps : Update -> 초당 100 실행 -> 10 * 100 = 1000  * Time.deltaTime

    }
}
