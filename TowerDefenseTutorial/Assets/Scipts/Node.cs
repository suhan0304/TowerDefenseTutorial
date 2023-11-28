using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor; //��

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
        GameObject turretBuild = BuildManager.instance.GetTurretToBuild(); //�̱���
        turret =  (GameObject)Instantiate(turretBuild, transform.position, transform.rotation);
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
