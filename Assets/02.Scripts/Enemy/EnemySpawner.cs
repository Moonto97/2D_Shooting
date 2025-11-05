using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float EnemyCoolTime = 2f;
    private float _timer;

    public void Start()
    {
        float randomCoolTime = Random.Range(1f, 2f);
        EnemyCoolTime = randomCoolTime;
    }


    public void Update()
    {
        //1. 시간이 흐르다가
        _timer += Time.deltaTime;
        //2. 쿨타임이 되면
        if (_timer >= EnemyCoolTime)
        {
            _timer = 0f;
            //3. 적 생성
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.position = transform.position;
        }
        

    }

}
