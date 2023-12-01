using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; //총알의 목표 오브젝트

    public float speed = 70f; //초알의 속도
    public float explosionRadius = 0f; //총알의 폭발 범위
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

        if (explosionRadius > 0f) //범위 공격
        {
            Explode();//폭발 함수
        }
        else //단일 타겟
        {
            Damage(target);//목표 오브젝트에만 Damage 함수
        }
        Destroy(gameObject);        //충돌 시 총알은 바로 파괴
    }

    void Explode() //총알 폭발 - 범위 공격
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //원으로 된 반경 이내 모든 콜라이더들을 불러오는 함수
        foreach (Collider collider  in colliders) //각 콜라이더를 접근하면서 에너미만 구별 = 어떻게? 태그로!
        {
            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("Explode Enemy1");
                Damage(collider.transform); //에너미 객체이며 + 폭발 범위 안에 있다? = 데미지 입력
            }
        }
    }

    void Damage(Transform enemy) // 데미지 입력
    {
        Destroy(enemy.gameObject);  // 일단은 적이 데미지 입력 시 바로 죽도록 설정
        Debug.Log("TODO List - (Health - Damage) Logic"); //추후 체력 업데이트 시 데미지 함수 수정 예정
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
