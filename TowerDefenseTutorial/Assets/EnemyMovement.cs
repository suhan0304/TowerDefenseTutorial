using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target; //��ǥ ����
    private int wavepointIndex = 0;//���� ��ǥ���ϴ� ��������Ʈ �ε���

    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();

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
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World); //World Space���� �̵�


        //��������Ʈ ���� �� ���� ��������Ʈ�� ����
        if (Vector3.Distance(transform.position, target.position) <= 0.4f) // ���� ����Ʈ�� ���ʹ��� �Ÿ��� 0.4 ���ϸ� ���� ���� ����Ʈ��
        {
            GetNextWayPoint(); //���� ��������Ʈ�� Ÿ������ ����
        }
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1) //���� ������ �ִ� ��� ��������Ʈ�� �湮 > ���� ���� ����
        {
            EndPath();
            return; //�Ʒ��� ���� ��������Ʈ �������� ���� ���� �ʰ� �ٷ� ����
        }

        wavepointIndex++; //���� ��������Ʈ �ε���
        target = WayPoints.points[wavepointIndex]; //���� �ε����� ��������Ʈ ������Ʈ�� �޾ƿ´�.
    }

    void EndPath() //����� ��(��ǥ)�� ����
    {
        Destroy(gameObject); //�������� ���� �� ������Ʈ �ı�
        PlayerStats.Lives--; // lives�� 1 ����
    }
}
