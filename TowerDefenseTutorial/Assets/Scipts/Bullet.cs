using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; //�Ѿ��� ��ǥ ������Ʈ

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
