using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float _timer;
    private float randomCoolTime = 1;

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
            //3. 적 생성
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.position = transform.position;
            randomCoolTime = Random.Range(1f, 5f);
        }
        

    }

}
