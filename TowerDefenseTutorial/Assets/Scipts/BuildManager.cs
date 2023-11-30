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
    public GameObject anotherTurretPrefab; //�ٸ� �ͷ� ������

    private GameObject turretToBuild; //��� ���� �� �Ǽ��� �ͷ�

    public GameObject GetTurretToBuild() //�Ǽ��� �ͷ��� �������� �Լ�
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)//�Ǽ��� �ͷ��� ����
    {
        turretToBuild = turret;
    }
}
