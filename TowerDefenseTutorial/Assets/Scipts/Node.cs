using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor; //��
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();//������ ���۵� �� �������� �̸� ����
        startColor = rend.material.color; //���� ���� ���� �� ���

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null) //�Ǽ��� �ͷ��� null (�Ǽ��� �ͷ��� �������� ������)
            return;                                  //��带 Ŭ���ص� �ͷ��� �Ǽ����� �ʰ� �׳� return ��Ŵ

        if(turret != null) //�ͷ� ������Ʈ�� null�� �ƴϸ� �̹� �ͷ��� �ִٴ� ���
        {
            Debug.Log("Can't build there! - TODO : Display on screen.");
            return;
        }

        //Build a turret
        GameObject turretBuild = BuildManager.instance.GetTurretToBuild(); //���� �Ŵ����� �ٷ� ȣ�� ����(�̱���)
        
        //��� ��ġ�� �Ǽ� �� ���� ������ Position�� ���ļ� ������ ( ��� ���ο� �ͷ��� ��ġ�� )
        //���� �������� ������ �� �� ��ġ ���Ϳ� ���ؼ� �ʱ� ���� ��ġ�� �������ش�. -> Offset�� ��� �������� �ν����Ϳ��� ���� ���� 
        turret =  (GameObject)Instantiate(turretBuild, transform.position + positionOffset, transform.rotation); //�Ǽ��� �ͷ��� ���� �� �� turret ������ �ʱ�ȭ
    }

    private void OnMouseEnter() //���콺�� ������Ʈ �浹ü�� �������ų� �� ��
    {
        if (buildManager.GetTurretToBuild() == null) //�Ǽ��� �ͷ��� null (�Ǽ��� �ͷ��� �������� ������)
            return;                                  //��忡 ���콺�� �ö�͵� ���̶���Ʈ ��Ű�� �ʰ� �׳� return ��Ŵ

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
