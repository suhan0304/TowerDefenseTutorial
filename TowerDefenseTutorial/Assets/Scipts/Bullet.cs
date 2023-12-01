using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; //총알의 목표 오브젝트

    public float speed = 70f; //초알의 속도
    public GameObject impactEffect; //총알 임팩트 효과

    public void Seek(Transform _target)
    {
        target = _target; //Turret으로부터 Target을 넘겨받음
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //목표가 null이 된다면 총알 파괴
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position; //총알이 바라볼 방향
        float distanceThisFrame = speed * Time.deltaTime;   //총알이 프레임마다 이동할 거리

        if (dir.magnitude <= distanceThisFrame) //dir의 크기가 프레임 거리보다 작아진다면 = 객체에 도달했다는 뜻
        {
            HitTarget(); // 목표에 도달
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //총알이 적을 향해 이동
        transform.LookAt(target); //총알이 적을 향해 바라보도록 설정
    }

    void HitTarget() //총알이 적에 도달했을때
    {
        //이펙트 생성(실행) 후 다시 제거
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); //이펙트 생성
        Destroy(effectIns, 2f); //2초후에 이펙트 다시 삭제

        Destroy(target.gameObject); //일단 바로 파괴하도록 작성 - 추후 HP 추가 예정
        Destroy(gameObject);        //충돌 시 총알은 바로 파괴
    }
}
