using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor; //��
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();//������ ���۵� �� �������� �̸� ����
        startColor = rend.material.color; //���� ���� ���� �� ���
    }

    private void OnMouseDown()
    {
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
