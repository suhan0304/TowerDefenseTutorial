using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target; // �����Ҹ�ǥ ������Ʈ
    public float range = 15f; // ��Ÿ��� 15�� ����

    public string enemyTag = "Enemy";

    public Transform partToRotate; //������ base�� �����ϰ� ȸ���� ������Ʈ�� Ʈ������
    public float turnSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //0f�� �����ؼ� 0.5f���� �ݺ�ȣ��
    }

    void UpdateTarget() //���� ����� ���� ã�� ��ǥ�� ������Ʈ
    {
        //�� �����Ӹ��� ��� ���� Ȯ���ϸ鼭 ������Ʈ�ϸ� ���� �ð� ����
        //"1�ʿ� 2��"�� ���� �˻� Ƚ���� ����, Ÿ���� ������ ���� ���� ��쿡�� Ž���ϴ� ���� ����� ����
        //0.5�ʿ� �ѹ� ���� �ǵ��� start�� InvokeRepeating�� ����

        GameObject[] enenmies = GameObject.FindGameObjectsWithTag(enemyTag); //�±׿� enemyTag�� ������Ʈ�� ��� Ž��
        float shortestDistance = Mathf.Infinity; //�ּҰŸ��� ���ϱ� ���� �ʱⰪ�� Infinity�� ����
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enenmies)
        {
            //���� �� �Ÿ��� ����
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) // �� ����� ���� ã�Ҵٸ� nearestEnemy�� �ִ� �Ÿ� ������Ʈ �� �ش� ������Ʈ�� ����  
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;               
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) //���� ã�Ұ� + ��Ÿ� �ȿ� ���Դٸ�
        {
            target = nearestEnemy.transform;    //���� ��ǥ ������Ʈ�� �̸� ã�Ƴ��� ������ ����
        }
        else
        {
            target = null; //�������� ������ target�� null�� �ʱ�ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //Ÿ���� ������ ���� (�ƹ��� �ൿ�� ���� ����)
            return;

        //--- ���� target�� �ִٸ� ---
        Vector3 dir = target.position - transform.position; //��ǥ ���� = Ÿ�� ��ġ - �� ��ġ
        Quaternion lookRotation = Quaternion.LookRotation(dir); //dir ������ ������ ȸ���ϴ� ����

        //����Ƽ�� x, y, z�� ���Ϸ� ������ �������� ����ϰ� �ִ�. 
        //Vector3 rotation = lookRotation.eulerAngles; //���� �츮�� ���ϴ�ȸ���� ���Ϸ� ������ ��ȯ���ش�.
        //���� �ڵ带 �Ʒ��� �ε巴�� ȸ���ϴ� �ڵ�� ����
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //partToRate�� ȸ������ lookRotation�� ȸ������ turnSpeed ������ ����Ǹ鼭 ȸ���� �������� �ش� ȸ���� ���Ϸ� ������ ��ȯ�ؼ� rotation Vector�� ������.

        //y���� �߽����θ� ȸ���ϱ⸦ ���ϱ� ������ yȸ�� ������ �ҷ��ͼ� ����Ѵ�.
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); 
        
    }

    private void OnDrawGizmosSelected() //����� �׷��ִ� ����Ƽ �Լ�
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); //�� ��ġ�� �������� range�� �������� ���� �׷���
    }
}
