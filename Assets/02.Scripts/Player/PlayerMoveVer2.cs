using UnityEngine;

public class PlayerMoveVer2 : MonoBehaviour
{
    [Header("능력치")]
    public float Speed = 0.1f;
    public float MaxSpeed = 15f;
    public float MinSpeed = 1f;
    public float SpeedAmount = 0.5f;    
    public float ShiftSpeed = 1.5f; // 원래 속도에 곱할 수
    [Header("이동 범위")]
    public float MaxX = 2.25f;
    public float MinX = -2.25f;
    public float MaxY = 5f;
    public float MinY = -5f;
    [Header("원점 위치")]
    private Vector2 _originPosition;
    [Header("총알 프리팹")]
    public GameObject bulletPrefab;

    
    void Start()
    {
        _originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 동작
        // 키보드 입력 감지

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(h, v); // 현재 위치에서 벡터값 h, v 로 방향 벡터 생성
        direction.Normalize(); // 방향 벡터 정규화
        Vector2 position = transform.position; // 현재 위치


        // 이동 구현
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Speed * h, Speed * v, 0);
        }
        
        if (Input.GetKey(KeyCode.R))    // 원점으로 이동 구현 (R,T 두가지 방식으로 구현함)
        {
            this.transform.position = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.T))
        {
            this.transform.Translate(-position.x, -position.y, 0);
        }









    }

}
