using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); // 노드 포지션이 아니라 빌드 포지션을 가져온다
                                                        // 노드 포지션이면 노드의 정중앙을 기준으로 위치

    }
}
