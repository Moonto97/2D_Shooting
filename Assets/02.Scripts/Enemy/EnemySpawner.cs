using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   

    public GameObject[] EnemyPrefabs;

    private float _timer;
    private float randomCoolTime = 1;
    public float CoolTimeMax = 3;
    public float CoolTimeMin = 1;

    public void Start()
    {
        
    }


    public void Update()
    {
        //1. 시간이 흐르다가
        _timer += Time.deltaTime;
        //2. 쿨타임이 되면
        if (_timer >= randomCoolTime)
        {
            _timer = 0f;
            randomCoolTime = Random.Range(CoolTimeMin, CoolTimeMax);
            //3. 적 생성
            if (UnityEngine.Random.Range(0, 100) > 70)
            {
                GameObject enemy = Instantiate(EnemyPrefabs[(int)EEnemyType.Directional]);  // (int)열거형 형변환 Enemy에 열거해놓은 EnemyType 에서 0번째인 Directional 을 가져옴
                enemy.transform.position = transform.position;
                randomCoolTime = Random.Range(CoolTimeMin, CoolTimeMax);
            }
            else
            {
                GameObject enemy = Instantiate(EnemyPrefabs[(int)EEnemyType.Trace]);
                enemy.transform.position = transform.position;
                randomCoolTime = Random.Range(CoolTimeMin, CoolTimeMax);
            }
            
            
        }
        

    }

}
