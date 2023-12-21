using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); // ��� �������� �ƴ϶� ���� �������� �����´�
        if (!target.isUpgraded) // ���׷��̵� ���� �ʾҴٸ�
        {
            upgradeCost.text = "$" + target.turretBlueprint.cost;
            upgradeButton.interactable = true; //��ư Ŭ�� Ȱ��ȭ
        } 
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false; //��ư Ŭ�� ��Ȱ��ȭ
        }
                   
        ui.SetActive(true); //NodeUI ������Ʈ�� Ȱ��ȭ
    }
    
    public void Hide()
    {
        ui.SetActive(false); //NodeUI ������Ʈ�� ��Ȱ��ȭ
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();//���׷��̵� �ϸ� ��� ���� ����
    }
}
