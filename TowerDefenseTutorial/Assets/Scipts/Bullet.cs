using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; //�Ѿ��� ��ǥ ������Ʈ

    public float speed = 70f; //�ʾ��� �ӵ�

    public void Seek(Transform _target)
    {
        target = _target; //Turret���κ��� Target�� �Ѱܹ���
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //��ǥ�� null�� �ȴٸ� �Ѿ� �ı�
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position; //�Ѿ��� �ٶ� ����
        float distanceThisFrame = speed * Time.deltaTime;   //�Ѿ��� �����Ӹ��� �̵��� �Ÿ�

        if (dir.magnitude <= distanceThisFrame) //dir�� ũ�Ⱑ ������ �Ÿ����� �۾����ٸ� = ��ü�� �����ߴٴ� ��
        {
            HitTarget(); // ��ǥ�� ����
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //�Ѿ��� ���� ���� �̵�
    }

    void HitTarget() //�Ѿ��� ���� ����������
    {
        Destroy(gameObject); 
    }
}
