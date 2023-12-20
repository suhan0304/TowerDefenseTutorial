using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); // 노드 포지션이 아니라 빌드 포지션을 가져온다
                   
        ui.SetActive(true); //NodeUI 오브젝트를 활성화
    }
    
    public void Hide()
    {
        ui.SetActive(false); //NodeUI 오브젝트를 비활성화
    }
}
