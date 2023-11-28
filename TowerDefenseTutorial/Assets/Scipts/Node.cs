using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor; //색

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();//게임이 시작될 때 렌더러를 미리 저장
        startColor = rend.material.color; //시작 색을 저장 후 기억
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
