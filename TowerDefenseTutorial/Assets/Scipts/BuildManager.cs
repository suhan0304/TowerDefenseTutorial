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

    public GameObject standardTurretPrefab; //�⺻ �ͷ� ������
    public GameObject missileLauncherPrefab; //�̻��� ��ó ������

    private TurretBlueprint turretToBuild; //��� ���� �� �Ǽ��� �ͷ�
    
    public bool CanBuild { get { return turretToBuild != null; } // �ͷ��� �Ǽ��� �� �ִ��� Ȯ���ϴ� �ο� ���� ( Build�� Turret�� Null�� �ƴϸ� True ��ȯ )

    public void BuildTurretOn(Node node)
    {
        Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset, )
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
