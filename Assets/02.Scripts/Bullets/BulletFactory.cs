using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [Header("총알 프리팹")]
    public GameObject bulletPrefab;
    public GameObject leftSubBulletPrefab;
    public GameObject rightSubBulletPrefab;

    public GameObject MakeBullet(Vector3 position)
    {
        return Instantiate(bulletPrefab, position, Quaternion.identity);
    }
    public GameObject MakeLeftBullet(Vector3 position)
    {
        return Instantiate(leftSubBulletPrefab, position, Quaternion.identity);
    }
    public GameObject MakeRightBullet(Vector3 position)
    {
        return Instantiate(rightSubBulletPrefab, position, Quaternion.identity);
    }
}
