using UnityEngine;
// 플레이어 이동
public class PlayerMove : MonoBehaviour
{
    [Header("능력치")]
    public float ShiftSpeed = 1.2f; // 원래 속도에 곱할 수
    public float MaxSpeed = 10f;

    [Header("이동 범위")]   
    public float MaxX = 2.25f;
    public float MinX = -2.25f;
    public float MaxY = 5f;
    public float MinY = -5f;

    private  Animator _animator;
    private Player _player;
    

    private void Start()
    {

        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();

    }


    public void Execute()
    {
        // 입력 받음
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(h, v);
        direction.Normalize();
        Vector2 position = transform.position;

        //if (direction.x > 0) _animator.Play("Right");
        //if (direction.x < 0) _animator.Play("Left");
        //if (direction.x == 0) _animator.Play("Idle");
        // 이 방식의 단점은 Transition, Timing, State 가 무시되고, 남용하기 쉬워서 어디서 애니메이션을 수정하는지 알 수 없어지게 된다.

        // 두번째 방식
        _animator.SetInteger("x", (int) direction.x);




        
        float speed = _player.Speed;


        Vector2 newPosition = position + direction * speed * Time.deltaTime;    // 새로운 위치

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
        float speed = _player.Speed;
        speed += value;

        if (speed >= MaxSpeed)
        {
            _player.Speed = MaxSpeed;
        }
    }

    
    

}
