using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor; //��
    public Color notEnoughMoneyColor; //��� ���� ����
    public Vector3 positionOffset;

    [Header("Optional")] //�̷��� Optional�� �س����� ���߿� ������ None���� �Ǿ��־ ����� ����
    public GameObject turret; //public���� �ؼ� BuildManager���� ���߿� �ͷ��� ������ �� �ֵ��� ��

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();//������ ���۵� �� �������� �̸� ����
        startColor = rend.material.color; //���� ���� ���� �� ���

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost) //�÷��̾��� ���� turret�� cost���� ���ٸ�
        {
            Debug.Log("Not Enough Money!"); //���� �����ϴٰ� ��� ��
            return;                         //�Ǽ����� �ʰ� ����
        }

        PlayerStats.Money -= blueprint.cost; //�ͷ��� �������Ƿ� �Ӵϸ� ��븸ŭ ����

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret; //node�� turret�� turret���� ����

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); // ����Ʈ �����ؼ� �������ֱ�
        Destroy(effect, 5f); // �����ϰ� 5���Ŀ� ����Ʈ ������Ʈ ����

        Debug.Log("Turret Build!");
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null) //�ͷ� ������Ʈ�� null�� �ƴϸ� �̹� �ͷ��� �ִٴ� ��� -> ��� ����
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) //�Ǽ��� �ͷ��� null�� �ƴϸ� True ���ϵ� (BuildManager ����)
            return;

        BuildTurret(blueprint); //��(this) ��忡 Turret�� �Ǽ�
}

    private void OnMouseEnter() //���콺�� ������Ʈ �浹ü�� �������ų� �� ��
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild) //�Ǽ��� �ͷ��� null�� �ƴϸ� True ���ϵ� (BuildManager ����)
            return;                                 

        //�������� �Ź� ���콺�� �� ������ �Ʒ��� ���� ã�� ���� ���� ���� -> ���� ���ۿ��� �� ���� ã�� ����
        //GetComponent<Renderer>().material.color = hoverColor;

        //���콺�� �÷������� �� �ǹ��� �Ǽ��� �� �ִ� ����� ���� �ִ��� Ȯ���� ��� ���� ����
        if(buildManager.HasMoney) //���� ����ϸ� hoverColor
        {
            rend.material.color = hoverColor;
        }
        else //���� �����ϸ� notEnoughMoneyColor
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit() //���콺�� ������Ʈ���� ���� ��
    {
        rend.material.color = startColor; //startColor�� �ǵ�����
    }
}
