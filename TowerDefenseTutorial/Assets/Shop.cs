using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start() //���� �Ŵ��� ������ ���� instance �ʱ�ȭ
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret() //�⺻ �ͷ� �Ǽ�
    {
        Debug.Log("Standard Turret Purchased"); //�׽�Ʈ�� ���
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab); //�⺻ �ͷ��� �Ǽ��ϵ��� ����
    }
    public void PurchaseAnotherTurret() //�ٸ� �ͷ� �Ǽ�
    {
        Debug.Log("Another Purchased"); //�׽�Ʈ�� ���
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab); //�ٸ� �ͷ��� �Ǽ��ϵ��� ����
    }
}
