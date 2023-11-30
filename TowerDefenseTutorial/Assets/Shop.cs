using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start() //빌드 매니저 참조를 위해 instance 초기화
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret() //기본 터렛 건설
    {
        Debug.Log("Standard Turret Purchased"); //테스트용 출력
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab); //기본 터렛을 건설하도록 설정
    }
    public void PurchaseAnotherTurret() //다른 터렛 건설
    {
        Debug.Log("Another Purchased"); //테스트용 출력
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab); //다른 터렛을 건설하도록 설정
    }
}
