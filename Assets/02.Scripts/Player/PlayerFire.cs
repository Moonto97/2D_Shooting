using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFire : MonoBehaviour
{
    // 목표 : 스페이스바를 누르면 총알을 만들어서 발사하고 싶다.

    // 필요 속성
    [Header("총알 프리팹")]
    public GameObject bulletPrefab;
    [Header("총구")]
    public Transform FirePosition;
    
    public float FireInterval = 0.5f;
    public float CoolTime = 0.6f;
    public float Timer = 0f;

    private bool AutoMode = false;


    private void Update()
    {
        Timer += Time.deltaTime;
        

        // 수동 발사
        if (Input.GetKey(KeyCode.Space))
        {
            if (Timer >= CoolTime)
            {
                Fire();
            }
        }


        // 자동 발사
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AutoMode = true;
            if (Timer >= CoolTime)
            {  Fire(); 
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            AutoMode = false;
            if (Timer >= CoolTime)
            {
                Fire();
            }
        }



    }

    private void Fire()
    {
        if (Input.GetKey(KeyCode.Space) || AutoMode)
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

            Timer = 0f;

        }


    }
}
