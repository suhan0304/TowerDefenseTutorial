using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor; //색
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

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) //건설할 터렛이 null이 아니면 True 리턴됨 (BuildManager 참고)
            return;

        if (turret != null) //터렛 오브젝트가 null이 아니면 이미 터렛이 있다는 모습
        {
            Debug.Log("Can't build there! - TODO : Display on screen.");
            return;
        }

        buildManager.BuildTurretOn(this); //이(this) 노드에 Turret을 건설
    }

    private void OnMouseEnter() //마우스가 오브젝트 충돌체에 지나가거나 들어갈 때
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild) //건설할 터렛이 null이 아니면 True 리턴됨 (BuildManager 참고)
            return;                                 

        //렌더러를 매번 마우스가 들어갈 때마다 아래와 같이 찾는 것은 성능 낭비 -> 게임 시작에서 한 번만 찾고 저장
        //GetComponent<Renderer>().material.color = hoverColor;

        //Start에서 저장된 렌더러를 호출해서 색을 변경
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() //마우스가 오브젝트에서 나갈 때
    {
        rend.material.color = startColor; //startColor로 되돌리기
    }
}
