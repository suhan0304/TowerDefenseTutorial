using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standradTurret; //�ͷ� û����
    public TurretBlueprint MissileLauncher; //�̻��� ��ó û����
    BuildManager buildManager;

    private void Start() //���� �Ŵ��� ������ ���� instance �ʱ�ȭ
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret() //�⺻ �ͷ� �Ǽ�
    {
        Debug.Log("Standard Turret Selected"); //�׽�Ʈ�� ���
        buildManager.SelectTurretToBuild(standradTurret); //�⺻ �ͷ��� �Ǽ��ϵ��� ����
    }
    public void SelectMissileLauncher() //�̻��� ��ó �Ǽ�
    {
        Debug.Log("Missile Launcher Selected"); //�׽�Ʈ�� ���
        buildManager.SelectTurretToBuild(MissileLauncher); //�̻��� ��ó�� �Ǽ��ϵ��� ����
    }
}