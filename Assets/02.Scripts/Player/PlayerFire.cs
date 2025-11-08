using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFire : MonoBehaviour
{
    // 목표 : 스페이스바를 누르면 총알을 만들어서 발사하고 싶다.

    // 필요 속성
    [Header("총알 프리팹")]
    public GameObject bulletPrefab;
    public GameObject leftSubBulletPrefab;
    public GameObject rightSubBulletPrefab;
    [Header("총구")]
    public Transform FirePosition;
    [Header("발사 옵션")]
    public float FireInterval = 0.5f;   // 총알 간 간격
    public float CoolTime = 0.6f;   // 총알 발사 후 쿨타임
    public float MaxCoolTime = 0.3f;
    private float _timer = 0f;

    private bool _autoMode = false;


    private void Update()
    {



        // 자동 발사    *** 처음에는 아래 코드를 if(Timer <= 0f)문 아래에 넣었었는데 
        // 발사가 시작된 후에 멈추는 Alpha2 키 입력이 먹히지 않았음.

        // 원인 분석
        // : Timer가 0 이하일 때만 if문 아래 코드가 실행되는데,
        // AutoMode가 true가 되면 Timer가 계속 초기화되기 때문에
        // "타이머가 Timer -= Time.deltaTime;에 의해 0이하가 되어
        // 아래 코드가 실행되는 순간" ~ "발사되기 직전의 순간"
        // 의 아주 짧은 한프레임의 순간에만 Alpha2 키 입력이 감지되는 것임.
        // 그 한 프레임을 놓치면 타이머가 다시 초기화되기 때문에
        // Alpha2 키 입력이 거의 먹히지 않는 것임.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _autoMode = true;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _autoMode = false;

        }


        _timer -= Time.deltaTime;
        // 타이머가 계속 줄어들고, 0 이하일 때만 밑의 코드 실행(발사)
        if (_timer >= 0f)
        {
            return;
        }

        



        if (Input.GetKey(KeyCode.Space) || _autoMode)
        {
            // 2. 프리팹으로부터 게임 오버젝트를 생성한다.
            // 유니티에서 게임 오브젝트를 생성할 때는 new가 아니라 Instantiate 라는 메서드를 이용한다.
            // 클래스 -> 객체(속성 + 기능) -> 메모리에 로드된 객체를 인스턴스라 한다.
            //                                인스턴스화 한다는 의미
            GameObject bullet1 = Instantiate(bulletPrefab); // 3. 총알 위치를 총구 위치로 바꾼다.
            bullet1.transform.position = FirePosition.position;

            GameObject bullet2 = Instantiate(bulletPrefab);
            bullet2.transform.position = FirePosition.position + new Vector3(-FireInterval, 0f, 0f);

            GameObject bullet3 = Instantiate(bulletPrefab);
            bullet3.transform.position = FirePosition.position + new Vector3(FireInterval, 0f, 0f);

            GameObject subBullet1 = Instantiate(leftSubBulletPrefab);
            subBullet1.transform.position = FirePosition.position + new Vector3(-FireInterval * 2f, 0f, 0f);
            GameObject subBullet2 = Instantiate(rightSubBulletPrefab);   
            subBullet2.transform.position = FirePosition.position + new Vector3(FireInterval * 2f, 0f, 0f);

            _timer = CoolTime;

        }

    }

    public void PowerUp (float power)
    {
        CoolTime -= power;
        if (CoolTime <= MaxCoolTime)
        {
            CoolTime = MaxCoolTime;
        }
    }

    

}
