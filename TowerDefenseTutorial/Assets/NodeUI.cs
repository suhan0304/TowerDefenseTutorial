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

        transform.position = target.GetBuildPosition(); // ��� �������� �ƴ϶� ���� �������� �����´�
                   
        ui.SetActive(true); //NodeUI ������Ʈ�� Ȱ��ȭ
    }
    
    public void Hide()
    {
        ui.SetActive(false); //NodeUI ������Ʈ�� ��Ȱ��ȭ
    }
}
