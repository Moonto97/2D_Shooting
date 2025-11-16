using UnityEngine;

public class BossFire : MonoBehaviour
{
    public GameObject InterceptorPrefab;
    private float _zenTime = 2f;
    private float _timer;
    private Vector3 vector = new Vector3(1, 0 , 0);
    
    private void Update()
    {
        Vector3 bossPosition = transform.position;
        _timer += Time.deltaTime;
        if(_timer >= _zenTime)
        {
            _timer = 0;
            GameObject interceptor2 = Instantiate(InterceptorPrefab, bossPosition + vector, Quaternion.identity);
            GameObject interceptor3 = Instantiate(InterceptorPrefab, bossPosition - vector, Quaternion.identity);
        }

    }
}
