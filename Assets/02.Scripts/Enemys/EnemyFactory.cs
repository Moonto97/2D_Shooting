using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private static EnemyFactory _instance;
    public static EnemyFactory Instance => _instance;
    [Header("적프리팹")]
    public GameObject EnemyPrefab;
    public GameObject TraceEnemyPrefab;
    [Header("풀링")]
    public int PoolSize = 20;
    private GameObject[] _enemyPool;
    private GameObject[] _traceEnemyPool;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        _instance = this;

        EnemyPoolInit();
        TraceEnemyPoolInit();
    }

    private void EnemyPoolInit()
    {
        _enemyPool = new GameObject[PoolSize];
        for (int i = 0; i < _enemyPool.Length; i++)
        {
            GameObject enemyObject = Instantiate(EnemyPrefab);
            _enemyPool[i] = enemyObject;
            enemyObject.SetActive(false);
        }
    }
    private void TraceEnemyPoolInit()
    {
        _traceEnemyPool = new GameObject[PoolSize];
        for (int i = 0; i < _enemyPool.Length; i++)
        {
            GameObject traceEnemyObject = Instantiate(TraceEnemyPrefab);
            _traceEnemyPool[i] = traceEnemyObject;
            traceEnemyObject.SetActive(false);
        }
    }

    public GameObject MakeEnemy(Vector3 position)
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject enemyObject = _enemyPool[i];
            if (enemyObject.activeInHierarchy == false)
            {
                enemyObject.transform.position = position;
                enemyObject.SetActive(true);
                return enemyObject;
            }
        }
        return null;
    }

    public GameObject MakeTraceEnemy(Vector3 position)
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject traceEnemyObject = _traceEnemyPool[i];
            if (traceEnemyObject.activeInHierarchy == false)
            {
                traceEnemyObject.transform.position = position;
                traceEnemyObject.SetActive(true);
                return traceEnemyObject;
            }
        }
        return null;
    }
}

