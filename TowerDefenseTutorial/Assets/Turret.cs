using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target; // 공격할목표 오브젝트
    public float range = 15f; // 사거리는 15로 설정

    public string enemyTag = "Enemy";

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
        }
        else
        {
            target = null; //만족하지 않으면 target을 null로 초기화
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //타겟이 없으면 리턴
            return;
    }

    private void OnDrawGizmosSelected() //기즈모를 그려주는 유니티 함수
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); //내 위치를 기준으로 range를 반지름을 구를 그려줌
    }
}
