using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 3;

    public bool AutoMode = false;

    

    private void Start()
    {
        
    }

    private void Update()
    {


        if(AutoMode)
        {
            // 자동 모드
            PlayerAutoMove autoMove = GetComponent<PlayerAutoMove>();
            autoMove.Execute();
        }
        else
        {
            // 수동 모드
            PlayerMove playerMove = GetComponent<PlayerMove>();
            playerMove.Execute();
        }
    }

    // 정리과제
    // 1. 각 스크립트의 gameObject는 누구인가
    // - 스크립트 (컴포넌트) 가 붙어 있는 주체
    // 2. GetComponent의 의미
    // - 게임 오브젝트에 붙어있는 컴포넌트 (트랜스폼, 리지드바디, 스크립트 등)
    //   을 GetComponent 를 입력한 스크립트에 가져와서 쓰겠다는 신호
    // ex ) Player player = GetComponent<Player>
    //      player.Execute   >> Player 스크립트 안의 Execute 메서드
    //      player.Speed = 15    >> Player 스크립트 안의 Speed 변수에 15를 대입한다.
    // 3. 값형 VS 참조형
    // 값형 : int dyAge = 29;
    //        int jhAge = 27;
    //        dyAge = jhAge;
    //        일 때 dyAge == 27
    // 참조형 : 
    // Student (string name, int Age);
    // Student dy = new Student ("김도영" , 29);
    // Student jh = new Student ("이재현" , 27);
    // dy = jh; 
    // 바로 위 코드에서 dy는 jh와 같은 객체를 가리키게 된다.
    // jh.Age = 23
    // dy.Age = ? 
    // jh 객체의 Age값에 23을 대입했으므로
    // jh 객체를 가리키게 된 dy 의 AGE 도 23이다.
}
