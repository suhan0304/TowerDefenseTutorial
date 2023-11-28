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

    private void Start()
    {
        turretToBuild = standardTurretPrefab; // ������ ���� �Ǽ��� �ϴ� �⺻ �ͷ��� �Ǽ��ǵ��� �ʱ�ȭ
    }

    private GameObject turretToBuild; //��� ���� �� �Ǽ��� �ͷ�

    public GameObject GetTurretToBuild() //�Ǽ��� �ͷ��� �������� �Լ�
    {
        return turretToBuild;
    }
}
