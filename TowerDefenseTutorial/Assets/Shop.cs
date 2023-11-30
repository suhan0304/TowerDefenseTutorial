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
        Debug.Log("Standard Turret Selected"); //�׽�Ʈ�� ���
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab); //�⺻ �ͷ��� �Ǽ��ϵ��� ����
    }
    public void PurchaseMissileLauncher() //�̻��� ��ó �Ǽ�
    {
        Debug.Log("Missile Launcher Selected"); //�׽�Ʈ�� ���
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab); //�̻��� ��ó�� �Ǽ��ϵ��� ����
    }
}
