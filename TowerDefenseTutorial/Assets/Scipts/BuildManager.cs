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
    public GameObject anotherTurretPrefab; //다른 터렛 프리팹

    private GameObject turretToBuild; //노드 선택 시 건설할 터렛

    public GameObject GetTurretToBuild() //건설할 터렛을 가져오는 함수
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)//건설할 터렛을 선택
    {
        turretToBuild = turret;
    }
}
