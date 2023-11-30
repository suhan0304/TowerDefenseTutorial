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
        Debug.Log("Standard Turret Selected"); //테스트용 출력
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab); //기본 터렛을 건설하도록 설정
    }
    public void PurchaseMissileLauncher() //미사일 런처 건설
    {
        Debug.Log("Missile Launcher Selected"); //테스트용 출력
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab); //미사일 런처를 건설하도록 설정
    }
}
