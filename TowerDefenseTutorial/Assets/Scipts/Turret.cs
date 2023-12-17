using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target; // 공격할목표 오브젝트
    private Enemy targetEnemy;

    [Header("General")]

    public float range = 15f; // 사거리는 15로 설정


    [Header("Use Bullets (default)")]

    public GameObject bulletPrefab; //총알 프리팹
    public float fireRate = 1f; //초당 발사하는 탄의 개수 (공격 속도)
    private float fireCountdown = 0f; //fireRate에 맞게 공격하도록 fireCountdown을 설정한 후 해당 주기마다 공격

    [Header("Use Laser (default)")]
    public bool useLaser = false; //레이저를 사용하는 포탑인가? (기본값은 False)

    public int damageOverTime = 30;

    public LineRenderer lineRenderer; //레이저를 사용하면 라인 렌더러가 필요함
    public ParticleSystem impactEffect; //레이저 이펙트
    public Light impactLight; // 조명 이펙트

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate; //실제로 base를 제외하고 회전될 오브젝트의 트랜스폼
    public float turnSpeed = 10f;

    public Transform firePoint; //총알이 복사되어 생성될 위치

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //0f에 시작해서 0.5f마다 반복호출
    }

    void UpdateTarget() //가장 가까운 적을 찾아 목표로 업데이트
    {
        //매 프레임마다 모든 적을 확인하면서 업데이트하면 성능 시간 낭비
        //"1초에 2번"과 같이 검색 횟수를 제한, 타겟을 가지고 있지 않은 경우에만 탐색하는 등의 방법이 가능
        //0.5초에 한번 실행 되도록 start에 InvokeRepeating을 실행
        
        GameObject[] enenmies = GameObject.FindGameObjectsWithTag(enemyTag); //태그에 enemyTag인 오브젝트를 모두 탐색
        float shortestDistance = Mathf.Infinity; //최소거리를 구하기 위한 초기값을 Infinity로 설정
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enenmies)
        {
            //적과 내 거리를 구함
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) // 더 가까운 적을 찾았다면 nearestEnemy를 최단 거리 업데이트 후 해당 오브젝트로 설정  
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;               
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) //적을 찾았고 + 사거리 안에 들어왔다면
        {
            target = nearestEnemy.transform;    //이제 목표 오브젝트를 미리 찾아놓은 적으로 설정
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null; //만족하지 않으면 target을 null로 초기화
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {//타겟이 없으면
            if(useLaser) //레이저 포탑은 레이저를 꺼줘야 함 ( 라인 렌더러를 지워줘야 함)
            {
                if (lineRenderer.enabled)
                { 
                    lineRenderer.enabled = false; //라인 렌더러 컴포넌트를 비활성화
                    impactEffect.Stop();  //이펙트 종료
                    impactLight.enabled = false; //Light 비활성화
                }
            }
            return;
        }

        //--- 만약 target이 있다면 ---
        //target Lock On
        LockOnTarget();

        if(useLaser) //레이저를 사용하는 포탑의 경우
        {
            Laser(); //레이저 그리기
        }
        else //일반 총알을 사용하는 경우 
        {
            if (fireCountdown <= 0f)
            { //카운트 다운이 0이 되면 shoot 발사
                Shoot();
                fireCountdown = 1f / fireRate; // 1초에 fireRate 만큼 발사되도록 Countdown 설정
            }

            fireCountdown -= Time.deltaTime; //카운트 다운을 계속 줄여서 shoot이 반복되도로 ㄱ설정
        }
        
    }

    void LockOnTarget()
    {
        //target Lock On
        Vector3 dir = target.position - transform.position; //목표 방향 = 타겟 위치 - 내 위치
        Quaternion lookRotation = Quaternion.LookRotation(dir); //dir 방향을 보도록 회전하는 정도

        //유니티는 x, y, z를 오일러 각도를 기준으로 사용하고 있다. 
        //Vector3 rotation = lookRotation.eulerAngles; //따라서 우리가 원하는회전을 오일러 각도로 변환해준다.
        //윗줄 코드를 아래의 부드럽게 회전하는 코드로 수정 
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //partToRate의 회전에서 lookRotation의 회전까지 turnSpeed 단위로 변경되면서 회전을 내보내면 해당 회전을 오일러 각도로 변환해서 rotation Vector에 저장함.

        //y축을 중심으로만 회전하기를 원하기 때문에 y회전 정도만 불러와서 사용한다.
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); 
    }
    void Laser() //레이저 그리기
    {
        //---- Damage ----
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);


        //----- Lase Graphic -----

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true; //레이저(라인 렌더러)가 꺼져있으면 키고 나서 위치 설정
            impactEffect.Play(); //파티클 시스템 재생
            impactLight.enabled = true; //Light 활성화
        }

        lineRenderer.SetPosition(0, firePoint.position); //시작점을 Fire Point로 
        lineRenderer.SetPosition(1, target.position); //끝점을 Fire Point로 

        Vector3 dir = firePoint.position - target.position; //총구로부터 타겟으로의 방향 벡터

        impactEffect.transform.position = target.position + dir.normalized * 1f;   //파티클 위치를 타겟 위치에서 살짝 터렛 방향으로 이동 시킨 위치로 생성
                                                                                    //레이저 이팩트가 적의 표면에 위치하도록 (중심에 위치X)
        impactEffect.transform.rotation = Quaternion.LookRotation(dir); //이펙트의 각도를 해당 방향 벡터로 설정
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>(); //복사한 bullet 오브젝트에서 bullet 컴포넌트를 가져옴

        if (bullet != null)
        {
            bullet.Seek(target); //bullet이 존재한다면 target 오브젝트를 넘겨줌
        }
    }


    private void OnDrawGizmosSelected() //기즈모를 그려주는 유니티 함수
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); //내 위치를 기준으로 range를 반지름을 구를 그려줌
    }
}
