using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public GameObject UltimatePrefab;
    private GameObject CopyUlt;
   public void UltimateActivate()
    {
        CopyUlt = Instantiate(UltimatePrefab);
    }
    public void UltimateDelete()
    {
        Destroy(CopyUlt);
    }
}
