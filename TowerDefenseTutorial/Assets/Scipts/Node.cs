using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor; //색
    public Color notEnoughMoneyColor; //비용 부족 노드색
    public Vector3 positionOffset;

    [Header("Optional")] //이렇게 Optional을 해놓으면 나중에 봤을때 None으로 되어있어도 놀라지 않음
    public GameObject turret; //public으로 해서 BuildManager에서 나중에 터렛을 설정할 수 있도록 함

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();//게임이 시작될 때 렌더러를 미리 저장
        startColor = rend.material.color; //시작 색을 저장 후 기억

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost) //플레이어의 돈이 turret의 cost보다 적다면
        {
            Debug.Log("Not Enough Money!"); //돈이 부족하다고 출력 후
            return;                         //건설하지 않고 리턴
        }

        PlayerStats.Money -= blueprint.cost; //터렛을 지었으므로 머니를 비용만큼 감소

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret; //node의 turret을 turret으로 설정

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); // 이펙트 복사해서 생성해주기
        Destroy(effect, 5f); // 생성하고 5초후에 이펙트 오브젝트 삭제

        Debug.Log("Turret Build!");
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null) //터렛 오브젝트가 null이 아니면 이미 터렛이 있다는 모습 -> 노드 선택
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) //건설할 터렛이 null이 아니면 True 리턴됨 (BuildManager 참고)
            return;

        BuildTurret(blueprint); //이(this) 노드에 Turret을 건설
}

    private void OnMouseEnter() //마우스가 오브젝트 충돌체에 지나가거나 들어갈 때
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild) //건설할 터렛이 null이 아니면 True 리턴됨 (BuildManager 참고)
            return;                                 

        //렌더러를 매번 마우스가 들어갈 때마다 아래와 같이 찾는 것은 성능 낭비 -> 게임 시작에서 한 번만 찾고 저장
        //GetComponent<Renderer>().material.color = hoverColor;

        //마우스를 올려놓았을 때 건물을 건설할 수 있는 충분한 돈이 있는지 확인후 노드 색을 변경
        if(buildManager.HasMoney) //돈이 충분하면 hoverColor
        {
            rend.material.color = hoverColor;
        }
        else //돈이 부족하면 notEnoughMoneyColor
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit() //마우스가 오브젝트에서 나갈 때
    {
        rend.material.color = startColor; //startColor로 되돌리기
    }
}
