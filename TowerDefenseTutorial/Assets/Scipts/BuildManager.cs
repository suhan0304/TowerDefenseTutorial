using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //�̱��� �������� ���� �Ŵ����� ����

    private void Awake()
    {
        if (instance != null)  //����� �� ������ �� �̻� ���� X
        {
            // �̹� ���� �Ŵ��� �ν��Ͻ��� ����
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        //������ �����ϸ� ���ο� ���� �Ŵ����� instance�� ����.
        //���� �Ŵ����� �ϳ��� �ν��Ͻ��θ� ������ (�̱��� ������ Ư¡ : �ϳ��� �ν��Ͻ��� ����)
        instance = this;
    }
    public GameObject buildEffect; //�Ǽ� ����Ʈ

    private TurretBlueprint turretToBuild; //��� ���� �� �Ǽ��� �ͷ�\
    private Node selectNode; // ������ ���

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } } // �ͷ��� �Ǽ��� �� �ִ��� Ȯ���ϴ� �ο� ���� ( Build�� Turret�� Null�� �ƴϸ� True ��ȯ )
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } } // �ͷ� ��뺸�� ������ ���� ������ Ȯ���ϴ� �Լ�

    public void SelectNode(Node node)
    {
        if (selectNode == node)
        {
            DeselectNode();
            return;
        }
        selectNode = node; //������ ��忡 �Ű����� ��带 ����
        turretToBuild = null; //�ǹ� �Ǽ��� �� �̻� ���� X

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret; //�Ǽ��ϱ����� ������ �ͷ��� turretToBuild�� �־��ش�.

        DeselectNode();
    }
}
