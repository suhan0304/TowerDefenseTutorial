using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target; // �����Ҹ�ǥ ������Ʈ
    public float range = 15f; // ��Ÿ��� 15�� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected() //����� �׷��ִ� ����Ƽ �Լ�
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); //�� ��ġ�� �������� range�� �������� ���� �׷���
    }
}
