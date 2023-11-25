using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; //�ӵ�

    private Transform target; //��ǥ ����
    private int wavepointIndex = 0;//���� ��ǥ���ϴ� ��������Ʈ �ε���

    private void Start()
    {
        //WayPoints�� points�� static���� �����س��� ������ �ٷ� �ҷ��� �� �ִ�.
        //points�� �̱��� ������ �������� ����ϴ� ���
        target = WayPoints.points[0]; 
    }

    void Update()
    {
        //�̵��ؾ� �� ���� ( ��ǥ ��ġ - �� ��ġ  )
        Vector3 dir = target.position - transform.position;

        //���� ���ͷ� ���ǵ� ��ŭ �̵�
        //������ �������ͷ� �ٲٱ� ���� normalized ���� �� speed�� ���Ѹ�ŭ ���� (������-�ð� �������� deltaTime�� ���)
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //World Space���� �̵�
        

    }
}
