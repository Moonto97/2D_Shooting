using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory _instance;     // 은닉화
    public static BulletFactory Instance => _instance;  // get 프로퍼티 이용. 전역성 확보 다른곳에서 읽을 수만 있게 함
    // public static BulletFactory Instance => _instance;
    // 무엇을 줄인 것인가?
    // public static BulletFactory Instance()
    // {
    //   get {_instance return}  // get 으로 _instance 값을 반환한다.
    // }

    [Header("총알 프리팹")]
    public GameObject bulletPrefab;
    public GameObject leftSubBulletPrefab;
    public GameObject rightSubBulletPrefab;

    [Header("풀링")]
    public int PoolSize = 30;
    private GameObject[] _bulletObjectPool; // 게임 총알을 담아둘 풀 : 탄창 열거할것이라 명시 []
    private GameObject[] _leftBulletObjectPool;
    private GameObject[] _rightBulletObjectPool;
    // Awake / Start/ Lazy
    // 1. 탄창에 총알을 담을 수 있는 크기 배열 만들어준다.
    // 2. 탄창 크기만큼 반복해서
    // 3. 총알을 생성한다.
    // 4. 생성한 총알을 탄창(풀)에 담는다.


    private void Awake()
    {
        // 인스턴스가 이미 생성된게 있다면
        // 후발주자들은 삭제해버린다.

        // 만약 인스턴스가 != 생성되면나오는 기본값(null)
        if (_instance != null)
        {
            // 생성되어있는 나 자신은 파괴
            Destroy(this.gameObject);
            return;
        }
        // 생성된 놈 몰아냈으니 진짜 인스턴스를 생성
        _instance = this;


        BulletPoolInit();
        LeftBulletPoolInit();
        RightBulletPoolInit();
    }
    private void BulletPoolInit()
    {
        // 1. 탄창에 총알을 담을 수 있는 크기 배열 만들어준다.
        // 위에서 열거한 게임 오브젝트 = 새로 메모리에 생성 게임 오브젝트 [PoolSize] << 인덱스 수 명시
        _bulletObjectPool = new GameObject[PoolSize];
        // 2. 탄창 크기만큼 반복해서
        for (int i = 0; i < PoolSize; i++)
        {
            // 3. 총알을 생성한다.
            GameObject bulletObject = Instantiate(bulletPrefab);
            // 4. 생성한 총알을 탄창(풀)에 담는다.
            // _bulletObjectPool 의 i인덱스 = 복사한 bulletPrefab
            _bulletObjectPool[i] = bulletObject;
            // 5. 비활성화 한다.
            bulletObject.SetActive(false);
            // 게임이 진행되며 오브젝트풀에 할당되었던 불렛이 파괴되면서
            // 오류 발생. 파괴로직을 없애고 파괴대신 비활성을 명령하면 됨.SetActiveFalse
            // 에너미에 이 풀링 패턴을 적용할때도 마찬가지일듯
        }
    }

    private void LeftBulletPoolInit()   // 불릿복사본 생성, 메모리에 열거
    {
        _leftBulletObjectPool = new GameObject[PoolSize];   // 불릿이 들어갈 빈 공간 생성
        for(int i = 0;i < PoolSize; i++)
        {
            GameObject leftBulletObject = Instantiate(leftSubBulletPrefab);     // 프리팹 원본 복사
            _leftBulletObjectPool[i] = leftBulletObject;    // 복사본을 빈 공간에 장전
            leftBulletObject.SetActive(false);  // 비활성화
        }
    }

    private void RightBulletPoolInit()
    {
        _rightBulletObjectPool = new GameObject[PoolSize];
        for( int i = 0;i <PoolSize; i++)
        {
            GameObject rightBulletObject = Instantiate(rightSubBulletPrefab);
            _rightBulletObjectPool[i] = rightBulletObject;
            rightBulletObject.SetActive(false);
        }
    }

    public GameObject MakeBullet(Vector3 position)  // 왜 Vector3를 받나? = Transform.position 이 z축의 값도 받기 때문
        // 여기서 위치, 생성이팩트, 등등 조절한다.
        // Vector3 position 은 MakeBullet을 호출하는 클래스에서 넣어줄 포지션의 값이다.
        // 내 게임의 경우엔 FirePosition 일 것이다.
    {
        // 1. 탄창(_bulletObjectPool) 안에 있는 총알(_bulletObjectPool[i])
        // 탄창안에 있는 총알들 중에서
        for (int i = 0; i < PoolSize; i++) // 총알하나하나 검사할 것이다
        {
            GameObject bulletObject = _bulletObjectPool[i];
            if (bulletObject.activeInHierarchy == false)    // 하이라키에 활성화 되어있는지. 아니라면(비활성화상태라면)
            {
                bulletObject.transform.position = position; // 받아온 position 값으로 이동시키고
                bulletObject.SetActive(true);   // 활성화시킨다 (Bullet이 작동한다.)

                return bulletObject;    // 총알을 반환한다.
            }
        }
        return null;    // GameObject 형태로 선언했기 때문에 반환할 값은 무조건 존재해야 한다.
                        // 반환할 값을 가지고 다른 방식으로 활용할 수 있게 하기 위해
                        // 굳이 GameObject 로 생성한 것.
                        // 정말 딱 위 기능만 가지고 만들 것이라면 void 로 만들어도 된다고 한다만
                        // 유연성을 위해 게임에서는 게임오브젝트를 가지고 놀아보자.
    }
    public GameObject MakeLeftBullet(Vector3 position)
    {
        for(int i = 0; i < PoolSize; i++)
        {
            GameObject leftBulletObject = _leftBulletObjectPool[i];
            if(leftBulletObject.activeInHierarchy == false)
            {
                leftBulletObject.transform.position = position;
                leftBulletObject.SetActive(true);
                return leftBulletObject;
            }
        }


        return null;
    }
    public GameObject MakeRightBullet(Vector3 position)
    {
        
        for (int i = 0; i < PoolSize; i ++)
        {
            GameObject rightBulletObject = _rightBulletObjectPool[i];
            if (rightBulletObject.activeInHierarchy == false)
            {
                rightBulletObject.transform.position = position;
                rightBulletObject.SetActive(true);
                return rightBulletObject;
            }
        }


        return null;
    }
}
