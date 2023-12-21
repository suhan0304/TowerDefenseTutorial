using UnityEditor.Experimental.GraphView;
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
    public GameObject buildEffect; //건설 이펙트

    private TurretBlueprint turretToBuild; //노드 선택 시 건설할 터렛\
    private Node selectNode; // 선택한 노드

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } } // 터렛을 건설할 수 있는지 확인하는 부울 변수 ( Build할 Turret이 Null이 아니면 True 반환 )
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } } // 터렛 비용보다 소지한 돈이 많은지 확인하는 함수

    public void SelectNode(Node node)
    {
        if (selectNode == node)
        {
            DeselectNode();
            return;
        }
        selectNode = node; //선택한 노드에 매개변수 노드를 연결
        turretToBuild = null; //건물 건설은 더 이상 진행 X

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret; //건설하기위해 선택한 터렛을 turretToBuild에 넣어준다.

        DeselectNode();
    }
}
