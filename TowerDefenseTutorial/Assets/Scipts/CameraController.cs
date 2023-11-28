using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f; //������� ī�޶� �����̴� �ӵ�
    public float panBorderThickness = 10; //ȭ���� ������ ���콺 �׵θ� ��ġ ����
    
    public float scrollSpeed = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //ESC Ű�� ���� doMovement�� �ο��� ������ �� �ִ�.
            doMovement = !doMovement;         //ESC Ű�� ���� ī�޶� �������� ���� �״� �� �� �ִ�.

        if (!doMovement) //doMovement�� False�̸� ī�޶� �������� �ʴ´�.
            return;

        //ī�޶� �̵� ����
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) //w �Է� �� or ���콺�� ȭ���� ��� (y ��ǥ - panBorderThickness) �ٱ��ʿ� ���� ��
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //�� �������� �̵�
            //deltaTime : �����ӿ� ������� ������ �Ÿ��� �̵��ϵ��� ����
            //Space.World : ���� ��ǥ�� �������� �̵��ϵ��� ���� - ȸ���� �����ϰ� �̵�
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) //s �Է� �� or ���콺�� ȭ���� �ϴ� (panBorderThickness) �ٱ��ʿ� ���� ��
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); 
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) //d �Է� �� or ���콺�� ȭ���� ������ (x ��ǥ - panBorderThickness) �ٱ��ʿ� ���� ��
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); 
        } 
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) //a �Է� �� or ���콺�� ȭ���� ���� (panBorderThickness) �ٱ��ʿ� ���� ��
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); 
        }

        //ī�޶� ������ �� ȸ�� ����
        //��ũ���� GetKeyó�� ����, �ȴ����� ���� 2���� ��찡 �ƴ϶� �ӵ��� ������ ��ȯ�Ѵ�. (�Ʒ� ������ ����, �� ������ ���)
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Debug.Log(scroll);

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime; //�� ��ȯ �� * �ӵ� * ������-�ð� ����

        transform.position = pos; //��ġ ����
    }
}
