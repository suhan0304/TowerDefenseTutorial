using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; //총알의 목표 오브젝트

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
