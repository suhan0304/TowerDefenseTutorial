using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f; //������� ī�޶� �����̴� �ӵ�
    public float panBorderThickness = 10; //ȭ���� ������ ���콺 �׵θ� ��ġ ����
    void Update()
    {
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) //w �Է� �� or ���콺�� ȭ���� ��� (y ��ǥ - panBorderThickness) �ٱ��ʿ� ���� ��
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //�� �������� �̵�
            //deltaTime : �����ӿ� ������� ������ �Ÿ��� �̵��ϵ��� ����
            //Space.World : ���� ��ǥ�� �������� �̵��ϵ��� ���� - ȸ���� �����ϰ� �̵�
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) //s �Է� �� or ���콺�� ȭ���� �ϴ� (panBorderThickness) �ٱ��ʿ� ���� ��
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); 
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) //d �Է� �� or ���콺�� ȭ���� ������ (x ��ǥ - panBorderThickness) �ٱ��ʿ� ���� ��
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); 
        } 
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) //a �Է� �� or ���콺�� ȭ���� ���� (panBorderThickness) �ٱ��ʿ� ���� ��
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); 
        }

    }
}
