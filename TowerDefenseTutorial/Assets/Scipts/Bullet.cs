using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; //�Ѿ��� ��ǥ ������Ʈ

    public float speed = 70f; //�ʾ��� �ӵ�
    public GameObject impactEffect; //�Ѿ� ����Ʈ ȿ��

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
        transform.LookAt(target); //�Ѿ��� ���� ���� �ٶ󺸵��� ����
    }

    void HitTarget() //�Ѿ��� ���� ����������
    {
        //����Ʈ ����(����) �� �ٽ� ����
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); //����Ʈ ����
        Destroy(effectIns, 2f); //2���Ŀ� ����Ʈ �ٽ� ����

        Destroy(target.gameObject); //�ϴ� �ٷ� �ı��ϵ��� �ۼ� - ���� HP �߰� ����
        Destroy(gameObject);        //�浹 �� �Ѿ��� �ٷ� �ı�
    }
}
