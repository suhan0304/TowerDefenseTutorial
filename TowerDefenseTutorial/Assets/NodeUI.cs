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

        transform.position = target.GetBuildPosition(); // 노드 포지션이 아니라 빌드 포지션을 가져온다
        if (!target.isUpgraded) // 업그레이드 하지 않았다면
        {
            upgradeCost.text = "$" + target.turretBlueprint.cost;
            upgradeButton.interactable = true; //버튼 클릭 활성화
        } 
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false; //버튼 클릭 비활성화
        }
                   
        ui.SetActive(true); //NodeUI 오브젝트를 활성화
    }
    
    public void Hide()
    {
        ui.SetActive(false); //NodeUI 오브젝트를 비활성화
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();//업그레이드 하면 노드 선택 해제
    }
}
