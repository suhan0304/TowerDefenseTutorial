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
    
    public bool CanBuild { get { return turretToBuild != null; } } // �ͷ��� �Ǽ��� �� �ִ��� Ȯ���ϴ� �ο� ���� ( Build�� Turret�� Null�� �ƴϸ� True ��ȯ )

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost) //�÷��̾��� ���� turret�� cost���� ���ٸ�
        {
            Debug.Log("Not Enough Money!"); //���� �����ϴٰ� ��� ��
            return;                         //�Ǽ����� �ʰ� ����
        }

        PlayerStats.Money -= turretToBuild.cost; //�ͷ��� �������Ƿ� �Ӵϸ� ��븸ŭ ����

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret; //node�� turret�� turret���� ����

        Debug.Log("Turret Build! Money Left : " + PlayerStats.Money); 
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret; //�Ǽ��ϱ����� ������ �ͷ��� turretToBuild�� �־��ش�.
    }
}
