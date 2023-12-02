using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor; //��
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

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) //�Ǽ��� �ͷ��� null�� �ƴϸ� True ���ϵ� (BuildManager ����)
            return;

        if (turret != null) //�ͷ� ������Ʈ�� null�� �ƴϸ� �̹� �ͷ��� �ִٴ� ���
        {
            Debug.Log("Can't build there! - TODO : Display on screen.");
            return;
        }

        buildManager.BuildTurretOn(this); //��(this) ��忡 Turret�� �Ǽ�
    }

    private void OnMouseEnter() //���콺�� ������Ʈ �浹ü�� �������ų� �� ��
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild) //�Ǽ��� �ͷ��� null�� �ƴϸ� True ���ϵ� (BuildManager ����)
            return;                                 

        //�������� �Ź� ���콺�� �� ������ �Ʒ��� ���� ã�� ���� ���� ���� -> ���� ���ۿ��� �� ���� ã�� ����
        //GetComponent<Renderer>().material.color = hoverColor;

        //Start���� ����� �������� ȣ���ؼ� ���� ����
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() //���콺�� ������Ʈ���� ���� ��
    {
        rend.material.color = startColor; //startColor�� �ǵ�����
    }
}
