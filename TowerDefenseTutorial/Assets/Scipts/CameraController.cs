using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f; //������� ī�޶� �����̴� �ӵ�
    void Update()
    {
        if(Input.GetKey("w")) //w �Է� ��
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //�� �������� �̵�
            //deltaTime : �����ӿ� ������� ������ �Ÿ��� �̵��ϵ��� ����
            //Space.World : ���� ��ǥ�� �������� �̵��ϵ��� ����
        }
        
    }
}
