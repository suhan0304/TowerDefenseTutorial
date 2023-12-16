using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standradTurret; //터렛 청사진
    public TurretBlueprint MissileLauncher; //미사일 런처 청사진
    public TurretBlueprint LaserBeamer; //레이저 포탑 청사진

    BuildManager buildManager;

    private void Start() //빌드 매니저 참조를 위해 instance 초기화
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret() //기본 터렛 건설
    {
        Debug.Log("Standard Turret Selected"); //테스트용 출력
        buildManager.SelectTurretToBuild(standradTurret); //기본 터렛을 건설하도록 설정
    }
    public void SelectMissileLauncher() //미사일 런처 건설
    {
        Debug.Log("Missile Launcher Selected"); //테스트용 출력
        buildManager.SelectTurretToBuild(MissileLauncher); //미사일 런처를 건설하도록 설정
    }
    public void LaserBeamerLauncher() //레이저 포탑 건설
    {
        Debug.Log("LaserBeamer Selected"); //테스트용 출력
        buildManager.SelectTurretToBuild(LaserBeamer); //레이저 포탑를 건설하도록 설정
    }
}
