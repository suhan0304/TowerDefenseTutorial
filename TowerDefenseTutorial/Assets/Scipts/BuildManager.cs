using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //싱글톤 패턴으로 빌드 매니저를 선언

    private void Awake()
    {
        if (instance != null)  //선언된 적 있으면 더 이상 선언 X
        {
            // 이미 빌드 매니저 인스턴스가 존재
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        //게임이 시작하면 새로운 빌드 매니저를 instance에 저장.
        //빌드 매니저는 하나의 인스턴스로만 유지됨 (싱글톤 패턴의 특징 : 하나의 인스턴스만 유지)
        instance = this;
    }

    public GameObject standardTurretPrefab; //기본 터렛 프리팹
    public GameObject missileLauncherPrefab; //미사일 런처 프리팹

    private TurretBlueprint turretToBuild; //노드 선택 시 건설할 터렛
    
    public bool CanBuild { get { return turretToBuild != null; } } // 터렛을 건설할 수 있는지 확인하는 부울 변수 ( Build할 Turret이 Null이 아니면 True 반환 )

    public void BuildTurretOn(Node node)
    {
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret; //node의 turret을 turret으로 설정
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
