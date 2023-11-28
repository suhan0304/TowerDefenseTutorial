using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor; //색
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();//게임이 시작될 때 렌더러를 미리 저장
        startColor = rend.material.color; //시작 색을 저장 후 기억
    }

    private void OnMouseDown()
    {
        if(turret != null) //터렛 오브젝트가 null이 아니면 이미 터렛이 있다는 모습
        {
            Debug.Log("Can't build there! - TODO : Display on screen.");
            return;
        }

        //Build a turret
        GameObject turretBuild = BuildManager.instance.GetTurretToBuild(); //빌드 매니저를 바로 호출 가능(싱그톤)
        
        //노드 위치에 건설 시 노드와 동일한 Position에 겹쳐서 생성됨 ( 노드 내부에 터렛이 위치함 )
        //높이 오프셋을 선언해 준 후 위치 벡터에 더해서 초기 생성 위치를 조정해준다. -> Offset은 노드 프리팹의 인스펙터에서 조정 가능 
        turret =  (GameObject)Instantiate(turretBuild, transform.position + positionOffset, transform.rotation); //건설할 터렛을 복사 한 후 turret 변수에 초기화
        
    }

    private void OnMouseEnter() //마우스가 오브젝트 충돌체에 지나가거나 들어갈 때
    {
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
